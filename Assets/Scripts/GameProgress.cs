using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Project.Scripts.ServiceLocator;
using System;

public class GameProgress : MonoBehaviour {

    public ReleaseWarning releaseText;
    [SerializeField] private float ReleaseTextStartValue = 0.75f;
    [SerializeField] private ReloadScript reload;
    [SerializeField] private RopeColorController ropeColorController;

    [SerializeField] private Transform Player;
    private float endPos;
    private float progress;
    private ShowInterstitialAd interstitialAd;
    private bool showIcon = false;
    private string currentSceneName;

    private void Start()
    {
        InputManager.Instance.OnGameStart += UpdateData;

        SL.GetSingle(out interstitialAd);
        interstitialAd.adMob.OnAddClose += loadCurrentScene;
        interstitialAd.adMob.OnAddFailed += loadCurrentScene;
    }

    private void loadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneName);
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnGameStart -= UpdateData;
        interstitialAd.adMob.OnAddClose -= loadCurrentScene;
        interstitialAd.adMob.OnAddFailed -= loadCurrentScene;

    }
    private void UpdateData() => endPos = LocalDB.Instance.db.data.ropeValue;
    
    
    private void FixedUpdate() {
        progress = Player.transform.position.z / endPos;

        ropeColorController.ChangeColor(progress);

        if(progress >= ReleaseTextStartValue && showIcon == false) {
            showIcon = true;
            //StartCoroutine(releaseText.Show());
            releaseText.Show();
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
        currentSceneName = "NextLevel";
        yield return new WaitForSeconds(10f);
        interstitialAd.ShowAd();
    }

    private IEnumerator ChangeScene() {
        reload.gameObject.SetActive(true);
        currentSceneName = "FailScene";
        yield return new WaitForSeconds(3f);
        interstitialAd.ShowAd();
    }
}
