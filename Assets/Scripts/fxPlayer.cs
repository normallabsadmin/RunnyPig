using UnityEngine;
using System.Collections;

public class fxPlayer : MonoBehaviour {

    public AudioClip _player0Jump;

    public AudioClip _player1Jump;

    public AudioClip _player2Jump;

    public AudioClip _player3Jump;

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
