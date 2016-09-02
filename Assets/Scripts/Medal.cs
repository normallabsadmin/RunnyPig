using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Medal : MonoBehaviour {

    public Sprite[] _medals;

    public void SetMedal(int score)
    {
        var medalHolder = GetComponent<Image>();

        if(score < 25)
        {
            medalHolder.sprite = _medals[0];
        }
        else if (score <= 50)
        {
            medalHolder.sprite = _medals[1];
        }
        else if (score <= 100)
        {
            medalHolder.sprite = _medals[2];
        }
        else if (score <= 150)
        {
            medalHolder.sprite = _medals[3];
        }
        else if (score <= 200)
        {
            medalHolder.sprite = _medals[4];
        }
    }
}
