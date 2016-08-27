using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        _scoreBoard.SetActive(false);
        _gameCanvas.SetActive(true);
        _goCanvas.SetActive(false);
        
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
