using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class PlayerTrigger : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.GetComponent<Ball>())
                other.gameObject.GetComponent<Ball>()
                    .OnPlayerTrigger(GetComponentInParent<ThrowPlayer>());

        }
    }
}