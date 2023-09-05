using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.ServiceLocator;
using Project.Scripts.Ads;

public class ShowInterstitialAd : MonoBehaviour, IService
{//TODO fix this NONFLEXIBLE GARBAGE 
    int counter;
    [SerializeField, Min(2)]
    int frequency;
    private readonly string playSceneName = "MainLevel";
    public AdMob adMob { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        SL.AddSingle(this, SetMode.Force);
        adMob = new AdMob();

        DontDestroyOnLoad(this);
    }

    public void ShowAd()
    {
        counter++;
        if (counter < frequency)
        {
            adMob.LoadInterstitialAd();
            return;
        }
        counter = 0;
        adMob.ShowAd();
    }
}
