using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            GetComponent<Text>().text = "Tap";
        }
        else
        {
            GetComponent<Text>().text = "Press Down";
        }
	}
	
	
}
