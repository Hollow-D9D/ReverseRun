using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject obstacle;
    private MeshRenderer rend;
    [SerializeField] private float destroyTime;



    // Start is called before the first frame update
    void Start()
    {
        
        SpawnObs();
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
           
    }

    void OnTriggerEnter( Collider other) 
    
    {

        if (other.tag == "rope" )
        { 
        
        //insert code here
              
        
        
        }


        if (other.tag == "fringe")
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
