using UnityEngine;

namespace Assets.Scripts.Obstacles {

    [RequireComponent(typeof(Rigidbody))]

    public class AdditionalObstacle : MonoBehaviour {
        [SerializeField] private float force;

        private Rigidbody rigidbody;

        private void Start() {
            rigidbody = GetComponent<Rigidbody>();
        }
        private void Update() {
            rigidbody.AddForce(-Vector3.forward * force * Time.deltaTime,ForceMode.VelocityChange);
        }

        public void OnPlayerTrigger(ThrowPlayer throwPlayer) {
            throwPlayer.End(1f);
            Destroy(gameObject);
        }
    }
}