using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem PFparticle;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(PFparticle, collision.transform);
    }
}
