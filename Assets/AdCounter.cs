using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdCounter : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "PLAYS UNTIL NEXT AD " + (15 - PlayerPrefs.GetInt("Deaths")).ToString("00");
	}
}
