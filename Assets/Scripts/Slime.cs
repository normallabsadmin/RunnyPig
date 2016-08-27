using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var rando = Random.Range(1, 3);
        Debug.Log(rando);
        if (rando == 1)
        {
            gameObject.transform.FindChild("Sprite_1").gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.FindChild("Sprite_2").gameObject.SetActive(false);
        }
    }
}
	
	
