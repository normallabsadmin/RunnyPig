using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    [Range(0.1f,10f)]
    public float _timeScaleMulti = 1;
    private float _lastTSM;

    public GameObject _player;
    public GameObject _musicBox;
    public GameObject _gameCanvas;
    public GameObject _goCanvas;
    public GameObject _scoreBoard;

    static GameObject _currentMusicBox;


    void Start()
    {
        if(_currentMusicBox == null)
        {
            _currentMusicBox = (GameObject)Instantiate(_musicBox,transform.position, Quaternion.identity);
        }
    }

    public void StartGame()
    {
        _scoreBoard.SetActive(true);
        _gameCanvas.SetActive(false);
        _goCanvas.SetActive(false);
        _player.GetComponent<RunnyPig>().StartGame();
        
    }

    public void EndGame()
    {
        var newScore = _scoreBoard.GetComponent<ScoreManager>()._myScore;
        _scoreBoard.SetActive(false);
        
        if(PlayerPrefs.GetInt("Deaths") < 15)
        {
            var dth = PlayerPrefs.GetInt("Deaths");
            PlayerPrefs.SetInt("Deaths", dth + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Deaths", 0);
            ShowAd();
        }


        _gameCanvas.SetActive(true);
        _gameCanvas.GetComponent<GameOver>().SetScore(newScore);
        _goCanvas.SetActive(false);
        
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }

    // Update is called once per frame
    void Update () {
	    if (_lastTSM != _timeScaleMulti)
        {
            Time.timeScale = _timeScaleMulti;
        }

        _lastTSM = _timeScaleMulti;
	}

    public void ResetScene()
    {
        SceneManager.LoadScene("level");
    }

}
