using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestScore : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        var texty = GetComponent<Text>();

        if(PlayerPrefs.GetInt("HighScore") != 0)
        {
            texty.text = PlayerPrefs.GetInt("HighScore").ToString("000");
        }
	}
}
