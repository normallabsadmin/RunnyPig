using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryText : MonoBehaviour
{

	void Start() { 
        if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                GetComponent<Text>().text = "RETRY";
            }
            else
            {
                GetComponent<Text>().text = "RETRY \n Press Down";
            }
    }
}
