using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.Obstacles {
    public class Energy : MonoBehaviour{

        [SerializeField] private float energy;

        [SerializeField] private Image energyBarPointer;
        [SerializeField] private GameObject energyBar;

        [SerializeField] private const int minPointerYValue = 0;
        [SerializeField] private const int maxPointerYValue = 250;
        

        private void Start() {
            SetPointerPosition();
            energyBarPointer.gameObject.SetActive(true);
        }

        public void ShowEnergyBar() {
            energyBar.SetActive(true);
        }

        public float GetEnergy() => energy;

        public void SetEnergy(float energyValue) {
            energy += energyValue;

            SetPointerPosition();
        }

        private void SetPointerPosition() =>
            energyBarPointer.fillAmount = energy;

        private float CalculateYValye() => 
            Mathf.Clamp(energy * 100,minPointerYValue,maxPointerYValue);
    }
}