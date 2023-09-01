using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationTrigger : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("chunk"))
        {
            LevelGeneration.Instance.Generate(rb.velocity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chunk"))
        {
            LevelGeneration.Instance.SetCurrent(other.name);
        }
    }
}
