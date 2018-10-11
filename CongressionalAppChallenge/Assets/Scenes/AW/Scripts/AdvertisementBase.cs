/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdvertisementBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #region Advertisments
    public void NoToAds()
    {
        Time.timeScale = 1;
        //adCanvas.SetActive(false);
        //GameManager.instance.GameOver();
    }
    public void ShowDefaultAd()
    {
        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            if (adCanvas != null)
                adCanvas.SetActive(false);
            menuButton.SetActive(true);
            return;
        }

        Advertisement.Show();
    }

    public void ShowRewardedAd()
    {
        const string RewardedPlacementId = "rewardedVideo";
        Time.timeScale = 1;
        menuButton.SetActive(false);
        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            if (adCanvas != null)
                adCanvas.SetActive(false);
            menuButton.SetActive(true);
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                if (adCanvas != null)
                    adCanvas.SetActive(false);
                menuButton.SetActive(true);
                stamina = stamina + staminaPerAd;
                staminaText.text = ("+" + staminaPerAd + " Stamina: " + stamina);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    #endregion

}*/
