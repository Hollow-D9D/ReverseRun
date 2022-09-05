using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody rb;
    private float screenWidth;
    private Transform playerTransform;
    [SerializeField] private float leftEdge = -18.5f;
    [SerializeField] private float rightEdge = -8.5f;

    private void Awake()
    {
        screenWidth = Screen.width;
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
        playerTransform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        inputManager.OnMove += Move;
    }

    private void Move(Vector2 pos)
    {
        StartCoroutine(movementRoutine());
    }

    float getDirRange()
    {
        return Mathf.Clamp((inputManager.getTouchX() / screenWidth) * (rightEdge - leftEdge) + leftEdge,leftEdge, rightEdge);
    }

    private IEnumerator movementRoutine()
    {
        Vector3 newPosition;
        while(true)
        {
            newPosition = new Vector3(getDirRange(), transform.position.y, transform.position.z);
            rb.MovePosition(newPosition);
            yield return null;
        }
    }
}
