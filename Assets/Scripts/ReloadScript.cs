using Project.Scripts.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour
{
    private ShowInterstitialAd interstitialAd;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        SL.GetSingle(out interstitialAd);
    }

    public void setName(string name) { sceneName = name; }

    // Update is called once per frame
    public void Reload()
    {
        interstitialAd.ShowAd();
    }

}
