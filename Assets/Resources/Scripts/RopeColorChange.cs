using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class RopeColorChange : MonoBehaviour
{
    [SerializeField] Material color;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    [SerializeField] Color color4;


    void Start()
    {
        color.color = Color.gray;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(5f);
        color.DOColor(color2, 5f).OnComplete(
        () => {
            color.DOColor(color3, 5f).OnComplete(
    () => { color.DOColor(color4, 10f); });
        });
    }

}
