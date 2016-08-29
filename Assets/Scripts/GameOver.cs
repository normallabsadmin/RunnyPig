using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public void SetScore(int score)
    {
        transform.FindChild("OverBox").FindChild("Score").GetComponent<Text>().text = score.ToString("000");
        transform.FindChild("OverBox").FindChild("Medal").GetComponent<Medal>().SetMedal(score);

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            transform.FindChild("OverBox").FindChild("NewHS").gameObject.SetActive(true);
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
