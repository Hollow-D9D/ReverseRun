using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class IntroPart : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera NearView;
    [SerializeField] private CinemachineVirtualCamera GameView;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        StartCoroutine(FTUE());
    }

    private IEnumerator FTUE()
    {
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
    void Update()
    {
        
    }
}
