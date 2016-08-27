using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [Range(1f,10f)]
    public float _timeScaleMulti = 1;
    private float _lastTSM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (_lastTSM != _timeScaleMulti)
        {
            Time.timeScale = _timeScaleMulti;
        }

        _lastTSM = _timeScaleMulti;
	}
}
