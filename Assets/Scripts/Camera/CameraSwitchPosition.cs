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
            winCam.Priority = 25;
        }
    
        public void Lose()
        {
            loseCam.Priority = 30;
        }
}
