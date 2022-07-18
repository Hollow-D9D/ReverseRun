using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private Image showProgress;
    [SerializeField] private Transform Player;

    private float startWidth;
    private float startX;
    private float endPos = -240;
    // Start is called before the first frame update
    void Start()
    {
        startX = showProgress.rectTransform.anchoredPosition.x;
        startWidth = showProgress.rectTransform.sizeDelta.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float progress = Player.transform.position.z / endPos * startWidth / -100;
        if (showProgress)
        {
            showProgress.fillAmount = 1 - progress;
            //Debug.Log(progress);
        }
            
        //showProgress.rectTransform.sizeDelta = new Vector2(startWidth - progress , showProgress.rectTransform.sizeDelta.y);
        //showProgress.rectTransform.anchoredPosition = new Vector2(startX + progress / 2 , showProgress.rectTransform.anchoredPosition.y );

    }
}
