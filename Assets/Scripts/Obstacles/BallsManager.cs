using UnityEngine;

namespace Assets.Scripts.Obstacles {
    public class BallsManager : MonoBehaviour {
        [SerializeField] private Transform[] spawns;
        [SerializeField] private GameObject ball;

        [SerializeField] private float startTime;
        [SerializeField] private float createPerNSeconds;

        private float _timer;
        private void Update() {
            if(startTime > 0) {
                startTime -= Time.deltaTime;
                return;
            }

            _timer += Time.deltaTime;

            if(_timer >= createPerNSeconds) {
                Instantiate(ball,GetRandomPosition(),Quaternion.identity);
                _timer = 0;
            }
        }

        private Vector3 GetRandomPosition() {
            return spawns[Random.Range(0,spawns.Length)].position;
        }
    }
}