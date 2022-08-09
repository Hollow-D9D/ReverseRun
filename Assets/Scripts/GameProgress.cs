using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
    }
    public void FailCor()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("FailScene");
    }
}
