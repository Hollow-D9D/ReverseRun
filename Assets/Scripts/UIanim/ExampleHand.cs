using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExampleHand : MonoBehaviour
{
        Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(
            transform.DOScale(new Vector3(1, 1, 1), 1).SetEase(Ease.OutExpo).SetDelay(1)).Append(
            transform.DORotate(new Vector3(60, 0, 0), 1, RotateMode.LocalAxisAdd).SetDelay(0.5f)).Append(
            transform.DOLocalMoveY(-500, 3).SetEase(Ease.OutCubic).SetDelay(0.3f)
            ).SetLoops(-1, LoopType.Restart); 
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
