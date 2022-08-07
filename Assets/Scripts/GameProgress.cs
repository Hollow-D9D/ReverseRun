using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour {
    private const float warningIconStartValue = 0.75f;
    [SerializeField] private WarningIcon warningIcon;

    [SerializeField] private RopeColorController ropeColorController;

    [SerializeField] private Image showProgress;
    [SerializeField] private Transform Player;

    private float startWidth;
    private float startX;
    private float endPos = -240;

    [SerializeField] private float progress;

    private bool showIcon;

    private void Start() {
        startX = showProgress.rectTransform.anchoredPosition.x;
        startWidth = showProgress.rectTransform.sizeDelta.x;
    }
    private void FixedUpdate() {
        progress = (Player.transform.position.z) / (endPos / 100) / 100;

        ropeColorController.ChangeColor(progress);

        if(progress >= warningIconStartValue && showIcon == false) {
            showIcon = true;
            StartCoroutine(warningIcon.Show());
        }

        if(showProgress) {
            showProgress.fillAmount = 1 - progress;
        }

        //showProgress.rectTransform.sizeDelta = new Vector2(startWidth - progress , showProgress.rectTransform.sizeDelta.y);
        //showProgress.rectTransform.anchoredPosition = new Vector2(startX + progress / 2 , showProgress.rectTransform.anchoredPosition.y );

    }
}
