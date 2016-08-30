using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdCounter : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        { 
            GetComponent<Text>().text = "PLAYS UNTIL NEXT AD " + (16 - PlayerPrefs.GetInt("Deaths")).ToString("00");
        }
    }
}
