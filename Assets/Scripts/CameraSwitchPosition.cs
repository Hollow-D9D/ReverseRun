using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraSwitchPosition : MonoBehaviour
{
        //Insert your final position & rotation here as an empty Transform
        public Transform target1;
        public Transform target2;
        public float movementTime = 1;
        public float rotationSpeed = 0.1f;

        Vector3 refPos;
        Vector3 refRot;

        void Update()
        {
        }

        public void CameraFromRight()
        {
            transform.DOLocalMove(target1.localPosition, 1f);
            transform.DORotate(target1.eulerAngles, 1f);
        }

        public void CameraUpfront()
        {
//            Vector3 desiredPos = targ
            transform.DOLocalMove(new Vector3(transform.localPosition.x + 4, transform.localPosition.y - 3, transform.localPosition.z), 1.5f);
            //transform.DORotate(target2.eulerAngles, 0.5f).SetEase(Ease.InBounce);
        }
}
