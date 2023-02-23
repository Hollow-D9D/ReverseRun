using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class InputManager : MonoBehaviour {

    [SerializeField] private ThrowPlayer tp;
    [SerializeField] private GameObject granny;
    [SerializeField] private GameObject image;
    private Animator anim;

    public bool inputIsEnabled = false;
    private float endPos = -240;
    private ForwardMovement fm;
    private Camera camera;
    private Rigidbody rb;
    public float progress;
    public int Gameover = 0;

    public delegate void StartMove(Vector2 position);
    public UnityEvent onTouchRelease;

    public event StartMove onTouchStart;

    private void Awake() {
        anim = granny.GetComponent<Animator>();
        camera = Camera.main;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();
        fm = GetComponent<ForwardMovement>();
    }

    private void OnEnable()
    {
        onTouchRelease.AddListener(GameOver);
    }

    private void OnDisable()
    {
        onTouchRelease.RemoveListener(GameOver);
    }

    private void Update()
    {
        if (inputIsEnabled && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            GameStart();
        else if (inputIsEnabled && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
            onTouchRelease.Invoke();
    }



    public void GameStart() {
        fm.enabled = true;

        image.SetActive(false);
        granny.transform.eulerAngles = new Vector3(0, 180, 0);
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        anim.SetBool("isStarted", true);
        //Debug.Log("GAME START"); 
        if(onTouchStart != null) onTouchStart(primaryPosition());
    }

    public Vector3 primaryPosition() {
        return Utils.ScreenToWorld(camera,Input.mousePosition);
    }

    public float getProgress() => transform.position.z / endPos;

    public void GameOver()
    {
        progress = transform.position.z / endPos; // -80  -240 

        GetComponent<ThrowPlayer>()?.End(progress);
        this.enabled = false;
    }
}
