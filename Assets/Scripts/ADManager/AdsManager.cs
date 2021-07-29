using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private BannerView bannerad;
    private InterstitialAd interstatial;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus=>{ });
        RequestBannerAd();
        RequestInterstatialAd();
        ShowInterstatialAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }
    private void RequestBannerAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        bannerad = new BannerView(adUnitId,AdSize.SmartBanner,AdPosition.Bottom);
        bannerad.LoadAd(CreateAdRequest());
    }
    private void RequestInterstatialAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        if (interstatial != null)
            interstatial.Destroy();

        interstatial = new InterstitialAd(adUnitId);
        interstatial.LoadAd(CreateAdRequest());
    }

    public void ShowInterstatialAd()
    {
        if(interstatial.IsLoaded())
        {
            interstatial.Show();
        }
    }
}
