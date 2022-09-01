using UnityEngine;
using Cinemachine;

namespace Assets.Scripts.Obstacles {
   
    public class Food : Collectable {

        [SerializeField] protected float percentToAdd;
        [SerializeField] protected float energyToAdd;
        
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.GetComponentInParent<ForwardMovement>())
                other.gameObject.GetComponentInParent<ForwardMovement>()
                    .OnValueChange(energyToAdd,percentToAdd);
            ScoreMultiplicator.GetInstance().Add(this);
            if (energyToAdd > 0)
            {
                Transform smokeParticle = other.transform.Find("Trail");
                smokeParticle.gameObject.GetComponent<ParticleSwitcher>().StartTimer();
            }
            Destroy(gameObject);
        }
    }
}