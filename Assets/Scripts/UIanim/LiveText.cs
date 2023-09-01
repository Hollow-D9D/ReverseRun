using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LiveText : MonoBehaviour
{
    Sequence sequence;
    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 1)).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
