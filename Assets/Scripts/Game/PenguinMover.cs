using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PenguinMover : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Rigidbody2D rigidBody;

        [SerializeField] private LineRenderer lineRenderer;

        [Header("Attributes")] [SerializeField]
        private float maxPower = 10f;

        [SerializeField] private float power = 2f;

        public bool isStopped = true;
        private readonly float linearDrag = 1.1f;
        private bool inHole;
        private bool isDrugging;
        private Camera mainCamera;
        [Inject] private MovesCount movesCount;
        private Vector2 startPoint;

        private void Start()
        {
            mainCamera = Camera.main;
            rigidBody.drag = linearDrag;
        }

        private void Update()
        {
            if (Time.timeScale < 1f)
                return;

            PlayerInput();
            if (!isStopped) CheckIsStopped();
        }

        public event Action OnStop;

        public event Action OnDragRelease;

        private void RotateTowardsMovement()
        {
            var velocityDirection = rigidBody.velocity.normalized;

            var angle = Mathf.Atan2(velocityDirection.y, velocityDirection.x) * Mathf.Rad2Deg;
            angle += 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void CheckIsStopped()
        {
            if (rigidBody.velocity.magnitude <= 0.4f)
            {
                OnStop?.Invoke();
                isStopped = true;
            }
        }

        private void PlayerInput()
        {
            if (!isStopped || movesCount.movesCount == 0) return;
            Vector2 inputPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && !isDrugging)
            {
                startPoint = inputPosition;
                DragStart();
            }

            if (Input.GetMouseButton(0) && isDrugging)
                DragChange(inputPosition);
            if (Input.GetMouseButtonUp(0) && isDrugging)
                DragRelease(inputPosition);
        }

        private void DragStart()
        {
            isDrugging = true;
            lineRenderer.positionCount = 2;
        }

        private void DragChange(Vector2 inputPosition)
        {
            var penguinPos = transform.position;

            var direction = startPoint - inputPosition;

            //Rotate in direction
            // var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // angle += 90f;
            // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            lineRenderer.SetPosition(0, penguinPos);
            lineRenderer.SetPosition(1,
                (Vector2)penguinPos + Vector2.ClampMagnitude(direction * power / 2, maxPower / 2));
        }

        private void DragRelease(Vector2 inputPosition)
        {
            var distance = Vector2.Distance(startPoint, inputPosition);
            isDrugging = false;
            lineRenderer.positionCount = 0;
            if (distance < 0.8f)
                return;
            OnDragRelease?.Invoke();
            isStopped = false;
            var direction = startPoint - inputPosition;

            rigidBody.velocity = Vector2.ClampMagnitude(direction * power, maxPower);
        }
    }
}