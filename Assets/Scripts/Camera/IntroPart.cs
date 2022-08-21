using System.Collections;
using UnityEngine;
using Cinemachine;

public class IntroPart : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera NearView;
    [SerializeField] private CinemachineVirtualCamera GameView;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Canvas canvas;
    
    void Awake() {
        if(PlayerPrefs.GetInt("HideIntro") == 1) 
            gameObject.SetActive(false);
        else {
            PlayerPrefs.SetInt("HideIntro",1);
            canvas.enabled = false;
            StartCoroutine(FTUE());
        }
    }

    private IEnumerator FTUE() {
        inputManager.touchControls.Disable();
        yield return new WaitForSeconds(1f);
        NearView.Priority = 12;
        yield return new WaitForSeconds(3f);
        GameView.Priority = 20;
        yield return new WaitForSeconds(2f);
        canvas.enabled = true;
        inputManager.touchControls.Enable();
    }
    // Update is called once per frame
    void Update() {

    }
}
