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
    [SerializeField] private float leftEdge = -18.5f;
    [SerializeField] private float rightEdge = -8.5f;


    private void Awake()
    {
        screenWidth = Screen.width;
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

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
            Debug.Log(getDirRange());
            //Debug.Log(inputManager.primaryPosition());
//                        transform.position = newPosition;
            //Debug.Log(inputManager.primaryPosition());
            rb.AddForce(newPosition / 3, ForceMode.Impulse);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
