using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
namespace Assets.Scripts.Obstacles {
   
    public class Food : Collectable {

        [SerializeField] protected float percentToAdd;
        [SerializeField] protected float energyToAdd;
        private ScreenEffect screenEffect;

        private void Start()
        {
            screenEffect = FindObjectOfType<ScreenEffect>();
        }

        private void OnTriggerEnter(Collider other) {
            ForwardMovement exo = other.gameObject.GetComponentInParent<ForwardMovement>();
            if(exo != null)
                exo.OnValueChange(energyToAdd,percentToAdd);
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