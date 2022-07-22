using UnityEngine;

namespace Assets.Scripts.Obstacles {
    public enum FoodType {
        Good,
        Rotten
    }
    public class Food : MonoBehaviour {

        [SerializeField] protected FoodType foodType;

        [SerializeField] protected float percentToAdd;
        [SerializeField] protected float energyToAdd;

        private void OnTriggerEnter(Collider other) {

            if(other.gameObject.GetComponentInParent<ForwardMovement>())
                other.gameObject.GetComponentInParent<ForwardMovement>()
                    .OnValueChange(energyToAdd,percentToAdd);

            Destroy(gameObject);
        }
    }
}