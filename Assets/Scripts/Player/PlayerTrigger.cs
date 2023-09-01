using Assets.Scripts.Obstacles;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject ragDoll;
        private void OnTriggerEnter(Collider other)
        {
            //    other.gameObject.GetComponent<Ball>()
            //        .OnPlayerTrigger(GetComponentInParent<ThrowPlayer>());
            if (other.gameObject.GetComponent<AdditionalObstacle>())
            {
                gameObject.SetActive(false);
                if (!ragDoll.activeSelf && InputManager.Instance != null)
                    InputManager.Instance.EndGame(1f);
            }
        }
    }
}