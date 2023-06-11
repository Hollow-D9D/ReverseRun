using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //    other.gameObject.GetComponent<Ball>()
            //        .OnPlayerTrigger(GetComponentInParent<ThrowPlayer>());
            if (other.gameObject.GetComponent<AdditionalObstacle>())
            {
                gameObject.SetActive(false);
                if (InputManager.Instance != null)
                    InputManager.Instance.EndGame(1f);
            }
        }
    }
}