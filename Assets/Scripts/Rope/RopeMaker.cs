using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMaker : MonoBehaviour
{
    [SerializeField] private int ropeCount;
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private Vector3 transformOffset;
    [SerializeField] private Transform player;
    [SerializeField] private InputManager inputManager;

    private Transform currentTransform;
    private DrawLine lineDrawer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position - (transformOffset * ropeCount);
        currentTransform = transform;
        lineDrawer = GetComponent<DrawLine>();
        CreateRope();
        Destroy(this);
    }

    void CreateRope()
    {

        for (int i = 0; i < ropeCount; ++i)
        {
            currentTransform = Instantiate(nodePrefab, currentTransform.position + transformOffset, currentTransform.rotation).transform;
            currentTransform.SetParent(player.transform);

            RopeStretchEffect rse = currentTransform.GetComponent<RopeStretchEffect>();
            rse.inputManager = inputManager;
            rse.startPoint = transform;

            lineDrawer.points.Add(currentTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
