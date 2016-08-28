using UnityEngine;
using System.Collections;

public class MusicBox : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Volume") == 0)
        {
            GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.2f;
        }
    }
}
