using UnityEngine;
using System.Collections;

public class Sucker : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        gameObject.transform.FindChild("Sprite_1").gameObject.SetActive(false);
        gameObject.transform.FindChild("Sprite_2").gameObject.SetActive(false);
        gameObject.transform.FindChild("Sprite_3").gameObject.SetActive(false);
        var rando = Random.Range(1, 4);
       // Debug.Log(rando);
        if (rando == 1)
        {
            gameObject.transform.FindChild("Sprite_1").gameObject.SetActive(true);
        }
        else if (rando == 2)
        {
            gameObject.transform.FindChild("Sprite_2").gameObject.SetActive(true);
        }
        else
        {
            gameObject.transform.FindChild("Sprite_3").gameObject.SetActive(true);
        }
    }
}
