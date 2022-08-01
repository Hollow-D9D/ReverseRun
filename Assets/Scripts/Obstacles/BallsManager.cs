using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Obstacles {
    public class BallsManager : MonoBehaviour {
        [SerializeField] private ForwardMovement movement;

        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject pointerIcon;
        [SerializeField] private Canvas pointersCanvas;

        [SerializeField] private Transform[] spawns;
        [SerializeField] private GameObject ball;

        [SerializeField] private float startTime;
        [SerializeField] private float createPerNSeconds;

        private float timer;
        private bool startShooting = true;

        private void Update() {
            if(!movement.enabled || !startShooting) return;

            if(startTime > 0) {
                startTime -= Time.deltaTime;
                return;
            }

            StartCoroutine(StartShooting());
        }

        private Vector3 GetRandomPosition() {
            return spawns[Random.Range(0,spawns.Length)].position;
        }

        private IEnumerator StartShooting() {
            startShooting = false;
            yield return new WaitForSeconds(createPerNSeconds);

            InitBall();
            startShooting = true;
        }

        private void InitBall() {
            GameObject ballPrefab = Instantiate(ball,GetRandomPosition(),Quaternion.identity);
            GameObject pointerIconPrefab =Instantiate(pointerIcon,pointersCanvas.transform);
            ballPrefab.GetComponentInChildren<BallPointer>()
                .Construct(playerTransform,
                pointerIconPrefab.transform,
                pointerIconPrefab.GetComponentInChildren<Image>());
        }
    }
}