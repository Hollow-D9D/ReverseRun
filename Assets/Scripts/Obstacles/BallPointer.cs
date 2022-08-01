using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class BallPointer : MonoBehaviour {
    [SerializeField] private Transform playerTransform;

    [SerializeField] private Transform pointerIconTransform;
    [SerializeField] private Image pointerIcon;

     private Camera camera;
    
    private void Start() {
        camera = Camera.main;
    }
    private void Update() {
        Vector3 toBall = transform.position - playerTransform.position;

        Ray ray = new Ray(playerTransform.position,toBall);
        //Debug.DrawRay(playerTransform.position,toBall);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

        float minDistance = Mathf.Infinity;
        if(planes[3].Raycast(ray,out float distance))
            if(distance < minDistance)
                minDistance = distance;

        minDistance = Mathf.Clamp(minDistance,0,toBall.magnitude);

        Vector3 worldPosition = ray.GetPoint(minDistance);

        pointerIconTransform.position = camera.WorldToScreenPoint(worldPosition);

        if(toBall.magnitude > minDistance)
                pointerIcon.enabled = true;
            else
                pointerIcon.enabled = false;
    }

    public void Construct(Transform playerTransform,Transform pointerIconTransform,Image pointerIcon) {
        this.playerTransform = playerTransform;
        this.pointerIconTransform = pointerIconTransform;
        this.pointerIcon = pointerIcon;
    }
}