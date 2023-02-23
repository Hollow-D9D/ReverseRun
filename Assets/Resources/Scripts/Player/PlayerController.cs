using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private Rigidbody rb;
    private float screenWidth;
    [SerializeField] private float leftEdge = -18.5f;
    [SerializeField] private float rightEdge = -8.5f;

    private void Awake()
    {
        screenWidth = Screen.width;
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.onTouchStart += Move;
        inputManager.onTouchRelease.AddListener(FinishRun);
    }

    private void OnDisable()
    {
        inputManager.onTouchStart -= Move;
        inputManager.onTouchRelease.RemoveListener(FinishRun);
    }

    private void Move(Vector2 pos)
    {
        StartCoroutine(movementRoutine());
    }

    float getDirRange()
    {
        return Mathf.Clamp((Input.mousePosition.x / screenWidth) * (rightEdge - leftEdge) + leftEdge,leftEdge, rightEdge);
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

    private void FinishRun()
    {
        ForwardMovement.Instance.enabled = false;
    }
}
