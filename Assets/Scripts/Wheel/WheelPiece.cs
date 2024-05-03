using System;
using UnityEngine;

namespace EasyUI.PickerWheelUI
{
    [Serializable]
    public class WheelPiece
    {
        public Sprite Icon;
        public string Label;

        [Tooltip("Reward amount")] public int Amount;

        [Tooltip("Probability in %")] [Range(0f, 100f)]
        public float Chance = 100f;

        [HideInInspector] public int Index;
        [HideInInspector] public double _weight;
    }
}