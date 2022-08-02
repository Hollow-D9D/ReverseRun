using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Obstacles {
#if UNITY_EDITOR
    [ExecuteAlways]
#endif
    public class BallPointer : MonoBehaviour {
        [SerializeField] private Transform playerTransform;

        [SerializeField] private Transform pointerIconTransform;
        [SerializeField] private Image pointerIcon;

        private Camera camera;

        private Vector3 toBall;
        private Vector3 worldPosition;
        private Ray ray;
        private Plane[] planes;
        private float minDistance;
        private void Start() {
            camera = Camera.main;
        }
        private void Update() {
            minDistance = Mathf.Infinity;

            toBall = transform.position - playerTransform.position;

            ray = new Ray(playerTransform.position,toBall);
            planes = GeometryUtility.CalculateFrustumPlanes(camera);

            CheckUpPlaneRaycast();

            minDistance = Mathf.Clamp(minDistance,0,toBall.magnitude);

            worldPosition = ray.GetPoint(minDistance);

            pointerIconTransform.position = camera.WorldToScreenPoint(worldPosition);

            SetVisabilityOfPointer();
        }
        public void Construct(Transform playerTransform,Transform pointerIconTransform,Image pointerIcon) {
            this.playerTransform = playerTransform;
            this.pointerIconTransform = pointerIconTransform;
            this.pointerIcon = pointerIcon;
        }

        private void SetVisabilityOfPointer() {
            if(toBall.magnitude > minDistance)
                pointerIcon.enabled = true;
            else
                pointerIcon.enabled = false;
        }

        private void CheckUpPlaneRaycast() {
            if(planes[3].Raycast(ray,out float distance))
                if(distance < minDistance)
                    minDistance = distance;
        }

    }
}