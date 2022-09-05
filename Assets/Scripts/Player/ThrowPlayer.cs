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
        if (progress >= 0.15f)
        {
            inputManager.Gameover = 1;
            rb.AddForce(Vector3.up * progress * upForce, ForceMode.Impulse);
            gameProgress.WinCor();
        }
        else
            gameProgress.FailCor();
        Debug.Log(inputManager.Gameover);
        //inputManager.touchControls.Disable();
        
    }

    public void End(float progress) {
        fm.enabled = false;
        rgSwitch.Switch();

        HidePointersAndRelease();
        
        if(progress < .88f) {
            Throw(progress);
        } else {
            Fail();

            gameProgress.FailCor();
            Debug.Log("Merar");
        }
        Destroy(GetComponent<PlayerController>());
        Destroy(this);
    }
    public void Fail()
    {
        inputManager.Gameover = 2;
        Camera.main.GetComponent<CameraSwitchPosition>().Lose();
        rb.AddForce(Vector3.up * 200, ForceMode.Impulse);
        rb.AddForce(Vector3.back * 200, ForceMode.Impulse);
        Time.timeScale = 0.8f;
    }


  

    private void HidePointersAndRelease() {
        addObsManager.DisablePointersAndBalls();
        gameProgress.releaseText.ShowText(false);
    }
}
