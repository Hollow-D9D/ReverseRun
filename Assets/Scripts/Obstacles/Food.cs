    using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

//Todo : Fix movement decrease 

namespace Assets.Scripts.Obstacles {
    public class Food : Collectable {

        protected float percentToAdd;
        protected float energyToAdd;

//        [SerializeField] private bool isRotten;
        private ScreenEffect screenEffect;

        private void Start()
        {
            screenEffect = FindObjectOfType<ScreenEffect>();
            energyToAdd = collectableType == CollectableType.Negative ?
                LocalDB.Instance.db.data.energyDecreaseValue :
                LocalDB.Instance.db.data.energyIncreaseValue;
            percentToAdd = energyToAdd;
            Debug.Log("Updated Energy: " + energyToAdd);
        }
        
        
        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.layer != 10)
                return;
            if(ForwardMovement.Instance != null)
                ForwardMovement.Instance.OnValueChange(energyToAdd,percentToAdd);
            ScoreMultiplicator.GetInstance().Add(this);
            if (energyToAdd > 0)
                screenEffect.AddEffect(Color.green);
            else
                screenEffect.AddEffect(Color.red);
                
                /*if (energyToAdd > 0)
                {
                    Debug.Log(other.gameObject.name);
                    Transform smokeParticle = other.transform.Find("Trail");
                    smokeParticle.gameObject.GetComponent<ParticleSwitcher>().StartTimer();
                }*/
                Destroy(gameObject);
        }
    }
}