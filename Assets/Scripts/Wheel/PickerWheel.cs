using System.Collections.Generic;
using DG.Tweening;
using Music;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;
using Random = System.Random;

namespace EasyUI.PickerWheelUI
{
    public class PickerWheel : MonoBehaviour
    {
        [Header("References :")] [SerializeField]
        private GameObject linePrefab;

        [SerializeField] private Transform linesParent;

        [Space] [SerializeField] private Transform PickerWheelTransform;

        [SerializeField] private Transform wheelCircle;
        [SerializeField] private GameObject wheelPiecePrefab;
        [SerializeField] private Transform wheelPiecesParent;

        [Space] [Header("Sounds :")] [SerializeField]
        private AudioSource audioSource;

        [SerializeField] private AudioClip tickAudioClip;
        [SerializeField] [Range(0f, 1f)] private float volume = .5f;
        [SerializeField] [Range(-3f, 3f)] private float pitch = 1f;

        [Space] [Header("Picker wheel settings :")] [Range(1, 20)]
        public int spinDuration = 8;

        [SerializeField] private int amountOfCircle = 6;

        [SerializeField] [Range(.2f, 2f)] private float wheelSize = 1f;

        [Space] [Header("Picker wheel pieces :")]
        public WheelPiece[] wheelPieces;


        private readonly List<int> nonZeroChancesIndices = new();
        private readonly Vector2 pieceMaxSize = new(144f, 213f);


        private readonly Vector2 pieceMinSize = new(81f, 146f);
        private readonly int piecesMax = 12;
        private readonly int piecesMin = 2;
        private readonly Random rand = new();


        private double accumulatedWeight;

        [Inject] private AudioManager audioManager;
        private float halfPieceAngle;
        private float halfPieceAngleWithPaddings;

        private UnityAction<WheelPiece> onSpinEndEvent;

        // Events
        private UnityAction onSpinStartEvent;

        private float pieceAngle;


        public bool IsSpinning { get; private set; }

        private void Start()
        {
            pieceAngle = 360 / wheelPieces.Length;
            halfPieceAngle = pieceAngle / 2f;
            halfPieceAngleWithPaddings = halfPieceAngle - halfPieceAngle / 4f;

            Generate();

            CalculateWeightsAndIndices();
            if (nonZeroChancesIndices.Count == 0)
                Debug.LogError("You can't set all pieces chance to zero");


            SetupAudio();
        }

        private void FixedUpdate()
        {
        }


        private void OnValidate()
        {
            if (PickerWheelTransform != null)
                PickerWheelTransform.localScale = new Vector3(wheelSize, wheelSize, 1f);

            if (wheelPieces.Length > piecesMax || wheelPieces.Length < piecesMin)
                Debug.LogError("[ PickerWheelwheel ]  pieces length must be between " + piecesMin + " and " +
                               piecesMax);
        }

        private void SetupAudio()
        {
            audioSource.clip = tickAudioClip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
        }

        private void Generate()
        {
            wheelPiecePrefab = InstantiatePiece();

            var rt = wheelPiecePrefab.transform.GetChild(0).GetComponent<RectTransform>();
            var pieceWidth = Mathf.Lerp(pieceMinSize.x, pieceMaxSize.x,
                1f - Mathf.InverseLerp(piecesMin, piecesMax, wheelPieces.Length));
            var pieceHeight = Mathf.Lerp(pieceMinSize.y, pieceMaxSize.y,
                1f - Mathf.InverseLerp(piecesMin, piecesMax, wheelPieces.Length));
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pieceWidth);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pieceHeight);

            for (var i = 0; i < wheelPieces.Length; i++)
                DrawPiece(i);

            Destroy(wheelPiecePrefab);
        }

        private void DrawPiece(int index)
        {
            var piece = wheelPieces[index];
            var pieceTrns = InstantiatePiece().transform.GetChild(0);

            pieceTrns.GetChild(0).GetComponent<Image>().sprite = piece.Icon;
            pieceTrns.GetChild(1).GetComponent<Text>().text = piece.Label;
            pieceTrns.GetChild(2).GetComponent<Text>().text = piece.Amount.ToString();

            //Line
            var lineTrns = Instantiate(linePrefab, linesParent.position, Quaternion.identity, linesParent).transform;
            lineTrns.RotateAround(wheelPiecesParent.position, Vector3.back, pieceAngle * index + halfPieceAngle);

            pieceTrns.RotateAround(wheelPiecesParent.position, Vector3.back, pieceAngle * index);
        }

        private GameObject InstantiatePiece()
        {
            return Instantiate(wheelPiecePrefab, wheelPiecesParent.position, Quaternion.identity, wheelPiecesParent);
        }


        public void Spin()
        {
            if (!IsSpinning)
            {
                IsSpinning = true;
                onSpinStartEvent?.Invoke();

                var index = GetRandomPieceIndex();
                var piece = wheelPieces[index];

                if (piece.Chance == 0 && nonZeroChancesIndices.Count != 0)
                {
                    index = nonZeroChancesIndices[UnityEngine.Random.Range(0, nonZeroChancesIndices.Count)];
                    piece = wheelPieces[index];
                }

                var angle = 360f / wheelPieces.Length * index;
                var endValue = angle - 360 * amountOfCircle;
                float previousSegment = 0;
                wheelCircle
                    .DORotate(new Vector3(0, 0, endValue), spinDuration, RotateMode.FastBeyond360)
                    .SetEase(Ease.OutQuad)
                    .OnUpdate(() =>
                    {
                        var currentSegment = Mathf.Floor(wheelCircle.eulerAngles.z / pieceAngle);
                        if (currentSegment != previousSegment)
                        {
                            audioManager.PlaySfx(audioManager.tickAudioClipSfx);
                            previousSegment = currentSegment;
                        }
                    })
                    .OnComplete(() =>
                    {
                        IsSpinning = false;
                        onSpinEndEvent?.Invoke(piece);

                        onSpinStartEvent = null;
                        onSpinEndEvent = null;
                    });
            }
        }


        public void OnSpinStart(UnityAction action)
        {
            onSpinStartEvent = action;
        }

        public void OnSpinEnd(UnityAction<WheelPiece> action)
        {
            onSpinEndEvent = action;
        }


        private int GetRandomPieceIndex()
        {
            var r = rand.NextDouble() * accumulatedWeight;

            for (var i = 0; i < wheelPieces.Length; i++)
                if (wheelPieces[i]._weight >= r)
                    return i;

            return 0;
        }

        private void CalculateWeightsAndIndices()
        {
            for (var i = 0; i < wheelPieces.Length; i++)
            {
                var piece = wheelPieces[i];

                //add weights:
                accumulatedWeight += piece.Chance;
                piece._weight = accumulatedWeight;

                //add index :
                piece.Index = i;

                //save non zero chance indices:
                if (piece.Chance > 0)
                    nonZeroChancesIndices.Add(i);
            }
        }
    }
}