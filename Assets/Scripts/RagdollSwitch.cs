using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitch : MonoBehaviour
{
    public GameObject ragDoll;
    [SerializeField] private GameObject model;

    public void Switch()
    {
        model.SetActive(false);
        ragDoll.SetActive(true);
        ragDoll.transform.position = model.transform.position - new Vector3(0f, 1.8f, 0f);
    }
}
