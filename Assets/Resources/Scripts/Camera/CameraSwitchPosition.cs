using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


public class CameraSwitchPosition : MonoBehaviour
{
        //Insert your final position & rotation here as an empty Transform
        [SerializeField] CinemachineVirtualCamera winCam;
        [SerializeField] CinemachineVirtualCamera loseCam;
        [SerializeField] CinemachineVirtualCamera mainCam;
        [SerializeField] CinemachineBrain brainCam;

        public void Win()
        {
            brainCam = GetComponent<CinemachineBrain>();
            winCam.Priority = 25;
            StartCoroutine(smoothTransition());            
        }
        
        IEnumerator smoothTransition()
        {
            Time.timeScale = 0.001f;
            yield return new WaitForSeconds(0.001f);
            Time.timeScale = 1f;
        }

        public void Lose()
        {
            loseCam.Priority = 30;
        }
}
