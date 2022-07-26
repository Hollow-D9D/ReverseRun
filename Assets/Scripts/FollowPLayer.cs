using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
    enum FollowAxis
    {
        x,
        y,
        z,
    }

    [SerializeField] private Transform player;
    [SerializeField] private FollowAxis chooseAxis;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos;
        if (chooseAxis == FollowAxis.x)
            newPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        else if (chooseAxis == FollowAxis.y)
            newPos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        else
            newPos = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);

        transform.position = newPos;
    }
}
