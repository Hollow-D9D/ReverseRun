using System;
using GoogleMobileAds.Api;
using Project.Scripts.ServiceLocator;
using UnityEngine;

namespace Project.Scripts.Ads
{
    public class AdMob : IService
    {
        #region Fields

        public bool noAd;
        private AdRequest adRequest;
        private Action<InterstitialAd, LoadAdError> loadAd;
        public BannerView bannerView;
#if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _adUnitId = "unused";
#endif

        private InterstitialAd interstitialAd;

        #endregion

        public event Action OnAddClose;
        public event Action OnAddFailed;

        #region Unity Lifecycle
      
        public AdMob()
        {
            loadAd = AdLoadCallback;
            MobileAds.Initialize((initStatus) => { });
            SL.AddSingle(this, SetMode.Force);

        }

        #endregion

        #region Methods

        public void LoadBannerAd()
        {
            bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
            var adRequest = new AdRequest();
           
            bannerView.LoadAd(adRequest);
        }

        public void LoadInterstitialAd()
        {
            if (interstitialAd != null && interstitialAd.CanShowAd()) return;
            RemoveLastAdd();

            adRequest = new AdRequest.Builder()
              .Build();

            InterstitialAd.Load(_adUnitId, adRequest, loadAd);
            OnAddFailed.Invoke();
        }

        private void AdLoadCallback(InterstitialAd ad, LoadAdError error)
        {
            if (error != null || ad == null)
            {
                return;
            }

            interstitialAd = ad;
            RegisterReloadHandler();
        }

        private void RemoveLastAdd()
        {
            if (interstitialAd == null) return;
            interstitialAd.OnAdFullScreenContentClosed -= Resume;
            interstitialAd.OnAdFullScreenContentFailed -= AdFailed;
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        public void ShowAd()
        {
            noAd = false;

            if (interstitialAd != null && interstitialAd.CanShowAd())
                interstitialAd.Show();
            else
            {
                noAd = true;
                OnAddFailed.Invoke();
            }
        }


        private void RegisterReloadHandler()
        {
            interstitialAd.OnAdFullScreenContentClosed += Resume;
            interstitialAd.OnAdFullScreenContentFailed += AdFailed;
        }

        private void Resume() => OnAddClose.Invoke();

        private void AdFailed(AdError obj) => OnAddFailed.Invoke();
        #endregion
    }
}
