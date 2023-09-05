using Project.Scripts.Ads;
using Project.Scripts.ServiceLocator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAd : MonoBehaviour
{
    AdMob adMob;
    // Start is called before the first frame update
    void Start()
    {
        SL.GetSingle(out adMob);
        adMob.LoadBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
