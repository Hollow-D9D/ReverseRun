﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Obstacles {
    public class Energy : MonoBehaviour{

        [SerializeField] private float energy;
        [SerializeField] private Image energyBarPointer;

        [SerializeField] private const int minPointerYValue = 0;
        [SerializeField] private const int maxPointerYValue = 250;

        private void Start() {
            SetPointerPosition();
            energyBarPointer.gameObject.SetActive(true);
        }

        public float GetEnergy() => energy;

        public void SetEnergy(float energyValue) {
            energy += energyValue;

            SetPointerPosition();
        }

        private void SetPointerPosition() =>
            energyBarPointer.rectTransform.anchoredPosition = new Vector3(0,CalculateYValye());

        private float CalculateYValye() => 
            Mathf.Clamp(energy * 100,minPointerYValue,maxPointerYValue);
    }
}