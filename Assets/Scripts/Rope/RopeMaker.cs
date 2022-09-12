using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMaker : MonoBehaviour
{
    [SerializeField] private int ropeCount;
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private Vector3 transformOffset;
    [SerializeField] private Transform player;
    
    private Rigidbody currentRb;
    private Transform currentTransform;
    private DrawLine lineDrawer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position - (transformOffset * ropeCount);
        currentTransform = transform;
        currentRb = GetComponent<Rigidbody>();
        lineDrawer = GetComponent<DrawLine>();
        CreateRope();
    }

    void CreateRope()
    {

        for (int i = 0; i < ropeCount; ++i)
        {
            currentTransform = Instantiate(nodePrefab, currentTransform.position + transformOffset, currentTransform.rotation).transform;
            currentTransform.GetComponent<ConfigurableJoint>().connectedBody = currentRb;
            currentRb = currentTransform.GetComponent<Rigidbody>();
            //Debug.Log(currentTransform.position);
            lineDrawer.points.Add(currentTransform);
        }
        player.gameObject.AddComponent<FixedJoint>().connectedBody = currentRb;
//        player.gameObject.GetComponent<FixedJoint>().massScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
