using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ThrowPlayer : MonoBehaviour
{
    [SerializeField] private float upForce, backForce;
    [SerializeField] private Image[] images;
    [SerializeField] private GameObject bone;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Rigidbody rbLeftArm;
    [SerializeField] private Rigidbody rbRightArm;
    [SerializeField] private GameObject winCamera;


    private Joint joint;
    private Camera cam;
    private CameraSwitchPosition cameraMove;
    private ForwardMovement fm;
    private RagdollSwitch rgSwitch;
    // Start is called before the first frame update
    void Awake()
    {
        rgSwitch = GetComponent<RagdollSwitch>();
        joint = bone.GetComponent<FixedJoint>();
        cam = Camera.main;
        fm = GetComponent<ForwardMovement>();
        cameraMove = cam.GetComponent<CameraSwitchPosition>();
    }

    private void Throw(float progress)
    {
        rb.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
       // rbLeftArm.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        //rbRightArm.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        if (progress >= 0.15f)
        {
            rb.AddForce(Vector3.up * progress * upForce, ForceMode.Impulse);
          //  rbLeftArm.AddForce(Vector3.forward * progress * upForce, ForceMode.Impulse);
           // rbRightArm.AddForce(Vector3.forward * progress * upForce, ForceMode.Impulse);
            cameraMove.CameraFromRight();
        }
    }

    public void End(float progress)
    {
        fm.enabled = false;
        Destroy(joint);
        Destroy(images[0]);
        Destroy(images[1]);
        rgSwitch.Switch();
        cam.gameObject.SetActive(false);
        winCamera.SetActive(true);
        if (progress < .88f)
            Throw(progress);
        else
            Fail();
    }

    public void Fail()
    {
        //rb.freezeRotation = false;
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        Time.timeScale = 0.8f;
        //cameraMove.CameraUpfront();
        cameraMove.CameraUpfront();
        Destroy(GetComponent<PlayerController>());
        Destroy(this);
        
        //Vector3 globalPos = transform.position;
            //new Vector3(transform.position.x + cam.transform.position.x, transform.position.y + cam.transform.position.y, transform.position.z + cam.transform.position.z);
        //cam.transform.parent = null;
        //cam.transform.position = globalPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
