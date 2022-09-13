using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] private Transform followObject;
    [SerializeField] private Vector3 offset;
    #endregion
    private Transform _transform;

    private void Awake() => _transform = transform;

    void Start()
    {
        if (followObject == null)
            Debug.LogError("Missing followObject");
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position = followObject.position + offset;
    }
}
