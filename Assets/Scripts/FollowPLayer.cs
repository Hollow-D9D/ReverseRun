using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPLayer : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
   }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + (rb.velocity.z * Time.deltaTime));
        transform.position = newPos;
    }
}
