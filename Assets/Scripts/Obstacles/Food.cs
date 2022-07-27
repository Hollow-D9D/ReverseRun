using UnityEngine;

namespace Assets.Scripts.Obstacles {
   
    public class Food : Collectable {

        [SerializeField] protected float percentToAdd;
        [SerializeField] protected float energyToAdd;

        private void OnTriggerEnter(Collider other) {

            if(other.gameObject.GetComponentInParent<ForwardMovement>())
                other.gameObject.GetComponentInParent<ForwardMovement>()
                    .OnValueChange(energyToAdd,percentToAdd);

            ScoreMultiplicator.GetInstance().Add(this);

            Destroy(gameObject);
        }
    }
}