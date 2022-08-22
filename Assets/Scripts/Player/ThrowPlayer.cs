using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.Obstacles;

public class ThrowPlayer : MonoBehaviour
{
    [SerializeField] private AdditionalObstacleManager addObsManager;
    [SerializeField] private float upForce, backForce;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameProgress gameProgress;

    private InputManager inputManager;
    private ForwardMovement fm;
    private RagdollSwitch rgSwitch;

    public bool IsForwardMovementEnabled()
    {
        return fm.enabled;
    }

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
        }
        else
            gameProgress.FailCor();
    }

    public void End(float progress) {
        fm.enabled = false;
        rgSwitch.Switch();

        HidePointersAndRelease();
        //cam.gameObject.SetActive(false);
        //winCamera.SetActive(true);

        if(progress < .88f) {
            Throw(progress);

            //  StartCoroutine(ScoreScene());
        } else {
            Fail();

            gameProgress.FailCor();
            Debug.Log("Merar");
        }
        // SceneManager.LoadScene("NextLevel");
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


    private IEnumerator ScoreScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("NextLevel");
    }

    private void HidePointersAndRelease() {
        addObsManager.DisablePointersAndBalls();
        gameProgress.releaseText.ShowText(false);
    }
}
