using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour {

    public Sprite[] _audioIcons;

    void Update()
    {
        var icony = GetComponent<Image>();

        icony.sprite = _audioIcons[PlayerPrefs.GetInt("Volume")];
    }

    public void ChangeVolume()
    {
        if(PlayerPrefs.GetInt("Volume") == 0)
        {
            PlayerPrefs.SetInt("Volume", 1);
        }else
        {
            PlayerPrefs.SetInt("Volume", 0);
        }
    }

   
}
