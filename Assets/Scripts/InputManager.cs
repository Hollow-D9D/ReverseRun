using Assets.Scripts.Obstacles;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviourSingleton<InputManager> {
    [SerializeField] private GameObject granny;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject UpgradePanel;

    public CustomButton startButton;
    public Action startAction;
    public event Action OnGameStart;
    private Animator anim;


    private float endPos;
    public PlayerControls touchControls;
    private ForwardMovement fm;
    public float progress;
    public int Gameover = 0;

    public delegate void StartMove(Vector2 position);

    public event StartMove OnMove;

    private void Awake()
    {
        base.Awake();
        anim = granny.GetComponent<Animator>();
        touchControls = new PlayerControls();
    }

    private void OnEnable() {
        touchControls.Enable();
    }

    private void OnDisable() {
        touchControls.Disable();
    }

    private void Start() {
       // startButton.enabled = false;
        startAction = GameStart;
        startButton.Action = startAction;

        fm = GetComponent<ForwardMovement>();
    }
    public void GameStart() {
        
        fm.enabled = true;
        endPos = LocalDB.Instance.db.data.ropeValue;
        OnGameStart.Invoke();
        touchControls.Touch.Start.canceled += GameOver;
        Destroy(image);
        granny.transform.eulerAngles = new Vector3(0, 180, 0);
        anim.SetBool("isStarted", true);
        UpgradePanel.SetActive(false);
        //Debug.Log("GAME START"); 
        if (OnMove != null) OnMove(primaryPosition());
    }

    public float getTouchX() {
        return touchControls.Touch.Move.ReadValue<Vector2>().x;
    }
    public Vector3 primaryPosition() {
        return Utils.ScreenToWorld(Camera.main,touchControls.Touch.Move.ReadValue<Vector2>());
    }

    public void GameOver(InputAction.CallbackContext ctx) {
        EndGame(getProgress());
    }

    public void EndGame(float progress)
    {
        touchControls.Touch.Start.canceled -= GameOver;
        ThrowPlayer.Instance.End(progress);

    }

    public float getProgress() => transform.position.z / endPos;
    public float getTransformValue() => -transform.position.z;
}
