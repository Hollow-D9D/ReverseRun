using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform camPosition;
    [SerializeField] private Transform ragDoll;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ragDoll.position);
        //transform.localPosition = new Vector3(ragDoll.transform.position.x - camPosition.localPosition.x, ragDoll.transform.position.y - camPosition.localPosition.y, ragDoll.transform.position.z - camPosition.localPosition.z);
        transform.position = ragDoll.position + offset;
        transform.LookAt(ragDoll);
    }
}
