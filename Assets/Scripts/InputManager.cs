using Assets.Scripts.Obstacles;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    [SerializeField] private ThrowPlayer tp;
    [SerializeField] private GameObject granny;
    [SerializeField] private GameObject image;
    private Animator anim;


    private float endPos = -240;
    public PlayerControls touchControls;
    private ForwardMovement fm;
    private Camera camera;
    private Rigidbody rb;
    public float progress;
    public  float  runprogress;
    public int Gameover = 0;

    public delegate void StartMove(Vector2 position);

    public event StartMove OnMove;

    private void Awake() {
        anim = granny.GetComponent<Animator>();
        touchControls = new PlayerControls();
        camera = Camera.main;
    }

    private void Update()
    { 
      runprogress = (transform.position.z) / (endPos / 100) / 100;

    }
    private void OnEnable() {
        touchControls.Enable();
    }

    private void OnDisable() {
        touchControls.Disable();
    }

    private void Start() {
        touchControls.Touch.Start.started += ctx => GameStart(ctx);
        touchControls.Touch.Start.canceled += ctx => GameOver(ctx);
        rb = GetComponent<Rigidbody>();
        fm = GetComponent<ForwardMovement>();

    }
    public void GameStart(InputAction.CallbackContext ctx) {
        fm.enabled = true;

        Destroy(image);
        granny.transform.eulerAngles = new Vector3(0, 180, 0);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        anim.SetBool("isStarted", true);
        //Debug.Log("GAME START"); 
        if(OnMove != null) OnMove(primaryPosition());
    }

    public float getTouchX() {
        return touchControls.Touch.Move.ReadValue<Vector2>().x;
    }
    public Vector3 primaryPosition() {
        return Utils.ScreenToWorld(camera,touchControls.Touch.Move.ReadValue<Vector2>());
    }

    public void GameOver(InputAction.CallbackContext ctx) {
      progress = (transform.position.z) / (endPos / 100) / 100;

        Debug.Log("asd"+progress);
       
        GetComponent<ThrowPlayer>()?.End(progress);
        touchControls.Disable();
    }

}
