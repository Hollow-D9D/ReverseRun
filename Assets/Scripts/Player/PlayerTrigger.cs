using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class PlayerTrigger : MonoBehaviour {

        private ThrowPlayer throwPlayer;
        private void Start() => 
            throwPlayer = GetComponentInParent<ThrowPlayer>();
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.GetComponent<Ball>())
                throwPlayer.End(1f);
        }
    }
}