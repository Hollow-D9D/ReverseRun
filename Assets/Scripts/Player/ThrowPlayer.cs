using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Obstacles;

public class ThrowPlayer : MonoBehaviour
{
    [SerializeField] private BallsManager ballsManager;
    [SerializeField] private float upForce, backForce;
    [SerializeField] private Image[] images;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameProgress gameProgress;

    private InputManager inputManager;
    private ForwardMovement fm;
    private RagdollSwitch rgSwitch;

    void Awake()
    {
        rgSwitch = GetComponent<RagdollSwitch>();
        fm = GetComponent<ForwardMovement>();
        inputManager = GetComponent<InputManager>();
    }
 
    private void Throw(float progress)
    {
        inputManager.Gameover = 2;
        Camera.main.GetComponent<CameraSwitchPosition>().Win();
        rb.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        // rbLeftArm.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        //rbRightArm.AddForce(Vector3.forward * progress * backForce, ForceMode.Impulse);
        if (progress >= 0.15f)
        {
            inputManager.Gameover = 1;
            rb.AddForce(Vector3.up * progress * upForce, ForceMode.Impulse);
            //  rbLeftArm.AddForce(Vector3.forward * progress * upForce, ForceMode.Impulse);
            // rbRightArm.AddForce(Vector3.forward * progress * upForce, ForceMode.Impulse);
            // cameraMove.CameraFromRight();
            StartCoroutine(ScoreScene());
            //SceneManager.LoadScene("NextLevel");
            Debug.Log("yes");
            Debug.Log("yes"+progress);
        }
        else
            gameProgress.FailCor();
    }

    public void End(float progress)
    {
        fm.enabled = false;
        rgSwitch.Switch();

        ballsManager.DisablePointersAndBalls();

        //cam.gameObject.SetActive(false);
        //winCamera.SetActive(true);

        if(progress < .88f)
        {
            Throw(progress);
            
          //  StartCoroutine(ScoreScene());
        }
        else
        {  Fail();

            gameProgress.FailCor();
            Debug.Log("Merar");
        }
       // SceneManager.LoadScene("NextLevel");
       
        
    }

    IEnumerator ScoreScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("NextLevel");
    }

    IEnumerator failScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("FailScene");
    }
    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Fail()
    {
        inputManager.Gameover = 2;
        Camera.main.GetComponent<CameraSwitchPosition>().Lose();
        //rb.freezeRotation = false;
        rb.AddForce(Vector3.up * 200, ForceMode.Impulse);
        rb.AddForce(Vector3.back * 200, ForceMode.Impulse);
        Time.timeScale = 0.8f;
        Destroy(GetComponent<PlayerController>());
        Destroy(this);     
        //SceneManager.LoadScene("FailScene");
        //Vector3 globalPos = transform.position;
        //new Vector3(transform.position.x + cam.transform.position.x, transform.position.y + cam.transform.position.y, transform.position.z + cam.transform.position.z);
        //cam.transform.parent = null;
        //cam.transform.position = globalPos;
        // Invoke("Fail_cor", 0.2f);
    }


}
