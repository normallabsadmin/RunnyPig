using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpText : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            GetComponent<Text>().text = "Tap Here to Jump";
        }
        else
        {
            GetComponent<Text>().text = "Press the Up Arrow To Jump";
        }
    }
}
