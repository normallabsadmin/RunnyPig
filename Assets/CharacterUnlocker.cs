using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class CharacterUnlocker : MonoBehaviour {



    public Image _myImage;
    public Text _myText;

    public string _unlockPref;

    public void SetUp(Sprite thisSprite, int thisCost, int unlockIndex)
    {
        _myImage.sprite = thisSprite;
        _myText.text = "Earn " + thisCost.ToString("000") + " Points to Unlock!";
        _unlockPref = "CharacterUnlocked" + unlockIndex.ToString();
    }

    public void BackButton()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
            Debug.Log("Trying Add");
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                PlayerPrefs.SetInt(_unlockPref, 1);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}

