﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityMonitization : MonoBehaviour, IUnityAdsListener
{
    string googlePlayID = "3844417";
    bool testMode = false;
    string myPlacementId = "rewardedVideo";
    public GameObject AdNotWorking;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(googlePlayID, testMode);
    }

    public void DisplayInterstitialAD() {
        Advertisement.Show();
    }

    public void DisplayVideoAD() {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            FindObjectOfType<GameManager>().Revive();
            Debug.LogWarning("you get a reward");
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
            FindObjectOfType<GameManager>().Died();
            Debug.LogWarning("you DONT get a reward");
        }
        else if (showResult == ShowResult.Failed)
        {
            FindObjectOfType<GameManager>().cantPlayAd();
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
