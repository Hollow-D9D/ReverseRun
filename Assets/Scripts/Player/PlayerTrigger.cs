using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class PlayerTrigger : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.GetComponent<Ball>())
                GetComponentInParent<ThrowPlayer>().End(1f);
        }
    }
}