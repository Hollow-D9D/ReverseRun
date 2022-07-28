using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Obstacles {
    public class BallsManager : MonoBehaviour {
        [SerializeField] private ForwardMovement movement;

        [SerializeField] private Transform[] spawns;
        [SerializeField] private GameObject ball;

        [SerializeField] private float startTime;
        [SerializeField] private float createPerNSeconds;

        private float timer;
        private bool startShooting;

        private IEnumerator Start() {
            if(movement.enabled == false)
                yield return null;

            while(true) {
                StartCoroutine(StartShooting());
            }
        }
        private void Update() {
            //if(startTime > 0) {
            //    startTime -= Time.deltaTime;
            //    return;
            //}

            //timer += Time.deltaTime;

            //if(timer >= createPerNSeconds) {
            //    Instantiate(ball,GetRandomPosition(),Quaternion.identity);
            //    timer = 0;
            //}

        }

        private Vector3 GetRandomPosition() {
            return spawns[Random.Range(0,spawns.Length)].position;
        }

        private IEnumerator StartShooting() {
            yield return new WaitForSeconds(createPerNSeconds);

            Instantiate(ball,GetRandomPosition(),Quaternion.identity);
        }
    }
}