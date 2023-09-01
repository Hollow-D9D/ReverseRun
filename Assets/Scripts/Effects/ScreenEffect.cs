using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ScreenEffect : MonoBehaviour
{
    Image image;
    float currentMaxOp;
    float changeTime;

    private void Start()
    {
        changeTime = .5f;
        currentMaxOp = .8f;
        image = GetComponent<Image>();
//        currentMaxOp = 0;
    }

    public void AddEffect(Color color)
    {
        image.DOPause();
        image.DOColor(color, changeTime).SetEase(Ease.OutCirc);
        image.DOFade(currentMaxOp, changeTime).OnComplete(() => image.DOFade(0f, changeTime).SetEase(Ease.InCirc));
    }

}
