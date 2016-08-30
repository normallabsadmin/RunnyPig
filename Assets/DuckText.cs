using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DuckText : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            GetComponent<Text>().text = "Tap and Hold here to Duck";
        }
        else
        {
            GetComponent<Text>().text = "Press the Down Arrow to Duck";
        }
    }
}
