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

    // Start is called before the first frame update
    void Start()
    {
        changeTime = .5f;
        currentMaxOp = .4f;
        image = GetComponent<Image>();
//        currentMaxOp = 0;
    }

    public void AddEffect(Color color)
    {
        image.DOPause();
        image.DOColor(color, changeTime).SetEase(Ease.OutCirc);
        image.DOFade(currentMaxOp, changeTime).OnComplete(() => image.DOFade(0f, changeTime).SetEase(Ease.InCirc));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
