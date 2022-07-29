using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class ThrowPlayer : MonoBehaviour
{
    [SerializeField] private float upForce, backForce;
    [SerializeField] private Image[] images;
    [SerializeField] private Rigidbody rb;

    private ForwardMovement fm;
    private RagdollSwitch rgSwitch;

    void Awake()
    {
        rgSwitch = GetComponent<RagdollSwitch>();
        fm = GetComponent<ForwardMovement>();
    }

    private void Throw(float progress)
    {
        Camera.main.GetComponent<CameraSwitchPosition>().Win();
        rb.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
       // rbLeftArm.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        //rbRightArm.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        if (progress >= 0.15f)
        {
            rb.AddForce(Vector3.up * progress * upForce, ForceMode.Impulse);
          //  rbLeftArm.AddForce(Vector3.forward * progress * upForce, ForceMode.Impulse);
           // rbRightArm.AddForce(Vector3.forward * progress * upForce, ForceMode.Impulse);
           // cameraMove.CameraFromRight();
        }
    }

    public void End(float progress)
    {
        fm.enabled = false;
        Destroy(images[0]);
        Destroy(images[1]);
        rgSwitch.Switch();
        //cam.gameObject.SetActive(false);
        //winCamera.SetActive(true);
        
        if (progress < .88f)
            Throw(progress);
        else
            Fail();
        StartCoroutine(reloadScene());
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Fail()
    {
        Camera.main.GetComponent<CameraSwitchPosition>().Lose();
        //rb.freezeRotation = false;
        rb.AddForce(Vector3.up * 200, ForceMode.Impulse);
        rb.AddForce(Vector3.back * 200, ForceMode.Impulse);
        Time.timeScale = 0.8f;
        //cameraMove.CameraUpfront();
        //cameraMove.CameraUpfront();
        Destroy(GetComponent<PlayerController>());
        Destroy(this);
        
        //Vector3 globalPos = transform.position;
            //new Vector3(transform.position.x + cam.transform.position.x, transform.position.y + cam.transform.position.y, transform.position.z + cam.transform.position.z);
        //cam.transform.parent = null;
        //cam.transform.position = globalPos;
    }
}
