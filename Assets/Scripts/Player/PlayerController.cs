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
    [SerializeField] private float borderOffset = 0.5f;
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
        //Debug.Log(pos);
        //rb.AddForce(Vector3.left * pos, ForceMode.Impulse);
        Vector3 newPosition = transform.position;
        newPosition.x = pos.x;
        transform.position = newPosition;
        StartCoroutine(movementRoutine());
    }

    float getDirRange()
    {
        return Mathf.Clamp((inputManager.getTouchX() * 2 / screenWidth - 1), -1, 1);
    }

    private IEnumerator movementRoutine()
    {
        Vector3 newPosition;
        while(true)
        {
            //newPosition = new Vector3(Mathf.Clamp(inputManager.primaryPosition().x, leftEdge, rightEdge), transform.position.y, transform.position.z);
            newPosition = new Vector3(getDirRange(), 0, 0);
            //Debug.Log(getDirRange());
            //Debug.Log(inputManager.primaryPosition());
            //transform.position = newPosition;
            //Debug.Log(inputManager.primaryPosition());
            if (!((Mathf.Abs(playerTransform.position.x - leftEdge) < borderOffset) || (Mathf.Abs(playerTransform.position.x - rightEdge) < borderOffset)))
                rb.AddForce(newPosition, ForceMode.VelocityChange);
            yield return null;
        }
    }
}
