using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextBounceUp : MonoBehaviour
{
    Sequence sequence;
    [SerializeField] int Delay = 1;

    void Start()
    {
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 1.5f).SetEase(Ease.OutElastic).SetDelay(Delay));
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}
