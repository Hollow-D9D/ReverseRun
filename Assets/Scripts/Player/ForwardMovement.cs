using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 2f;
    private float endPos = -240;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.z > -10)
            rb.AddForce(Vector3.back * speed, ForceMode.VelocityChange);
        float progress = transform.position.z / (endPos / 100) / 100 ;
//        Debug.Log(Screen.currentResolution.height);
        if (progress > 0.88f)
            GetComponent<ThrowPlayer>().End(progress);
        //        Debug.Log(rb.velocity.z);
    }
}
