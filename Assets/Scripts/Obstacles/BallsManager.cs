using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Obstacles {
    public class BallsManager : MonoBehaviour {
        private const float destroyAfterNSeconds = 10f;

        [SerializeField] private ForwardMovement movement;

        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject pointerIcon;
        [SerializeField] private Canvas pointersCanvas;

        [SerializeField] private Transform[] spawns;
        [SerializeField] private GameObject ball;

        [SerializeField] private float startTime;
        [SerializeField] private float createPerNSeconds;

        private bool startShooting = true;
        private List<GameObject> pointersList;
        private List<GameObject> ballsList;

        private void Start() {
            pointersList = new List<GameObject>();
            ballsList = new List<GameObject>();
        }

        private void Update() {
            if(!movement.enabled || !startShooting) return;

            if(startTime > 0) {
                startTime -= Time.deltaTime;
                return;
            }

            StartCoroutine(StartShooting());
        }

        public void DisablePointersAndBalls() {
            for(int i = 0;i < pointersList.Count;i++) {
                Destroy(pointersList[i]);
                Destroy(ballsList[i]);
            }
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
            GameObject pointerIconPrefab = Instantiate(pointerIcon,pointersCanvas.transform);
            pointersList.Add(pointerIconPrefab);
            ballsList.Add(ballPrefab);

            ballPrefab.GetComponentInChildren<BallPointer>()
                .Construct(playerTransform,
                pointerIconPrefab.transform,
                pointerIconPrefab.GetComponentInChildren<Image>());

            // Destroy(ballPrefab,destroyAfterNSeconds);
            // Destroy(pointerIconPrefab,destroyAfterNSeconds);
        }
    }
}