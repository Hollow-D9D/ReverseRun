using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameProgress : MonoBehaviour {

    public ReleaseWarning releaseText;
    [SerializeField] private float ReleaseTextStartValue = 0.75f;
    [SerializeField] private ReloadScript reload;
    [SerializeField] private RopeColorController ropeColorController;

    [SerializeField] private Transform Player;

    private float endPos = -240;
    private float progress;

    private bool showIcon = false;

    private void FixedUpdate() {
        progress = (Player.transform.position.z) / (endPos / 100) / 100;

        ropeColorController.ChangeColor(progress);

        if(progress >= ReleaseTextStartValue && showIcon == false) {
            showIcon = true;
            StartCoroutine(releaseText.Show());
        }
    }
    public void FailCor() {
        StartCoroutine(ChangeScene());
    }

    public void WinCor()
    {
        StartCoroutine(ScoreScene());
    }

    private IEnumerator ScoreScene()
    {
        reload.gameObject.SetActive(true);
        reload.setName("NextLevel");
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("NextLevel");
    }

    private IEnumerator ChangeScene() {
        reload.gameObject.SetActive(true);
        reload.setName("FailScene");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("FailScene");
    }
}
