using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject obstacle;
    private MeshRenderer rend;
    [SerializeField] private float destroyTime;

    void Start()
    {
        SpawnObs();
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    void OnTriggerEnter( Collider other) 
    {
        if (other.tag == "rope" )
        { 
            //insert code here
        }
        else if (other.tag == "fringe")
        {
            Invoke("SpawnObs", 1);
                 
        }
    }

    public void SpawnObs()
    {
        GetComponent<MeshRenderer>().enabled = true;

        Destroy(gameObject, destroyTime);
    }
}
