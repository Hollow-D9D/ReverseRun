using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour {
    private const float warningIconStartValue = 0.1f;
    [SerializeField] private ReleaseWarning warningText;

    [SerializeField] private RopeColorController ropeColorController;

    [SerializeField] private Transform Player;

    private float startWidth;
    private float startX;
    private float endPos = -240;

    [SerializeField] private float progress;

    private bool showIcon;

  
    private void FixedUpdate() {
        progress = (Player.transform.position.z) / (endPos / 100) / 100;

        ropeColorController.ChangeColor(progress);

        if(progress >= warningIconStartValue && showIcon == false) {
            showIcon = true;
            StartCoroutine(warningText.Show());
        }
        //showProgress.rectTransform.sizeDelta = new Vector2(startWidth - progress , showProgress.rectTransform.sizeDelta.y);
        //showProgress.rectTransform.anchoredPosition = new Vector2(startX + progress / 2 , showProgress.rectTransform.anchoredPosition.y );

    }
}
