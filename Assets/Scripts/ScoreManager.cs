using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int _myScore;
    private int _previousScore;
    public Sprite[] _numberSprites;
    public Image _ones;
    public Image _tens;
    public Image _hundreds;
    [Tooltip("Higher Numbers are easier")]
    public float _accelPlayRate = 30f;

    void Start()
    {
        _ones.sprite = _numberSprites[_myScore];

        var v3Pos = new Vector2(0.0f, 1.0f);
        transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
    }

    void Update()
    {
        if (_previousScore != _myScore)
        {

            _hundreds.sprite = _numberSprites[_myScore / 100];
            int rest = _myScore % 100;
            _tens.sprite = _numberSprites[rest / 10];
            _ones.sprite = _numberSprites[rest % 10];

            var gameManager = transform.parent.GetComponent<GameManager>();
            gameManager._timeScaleMulti = 1.5f + ((float)_myScore/ _accelPlayRate);

            _previousScore = _myScore;

         

        }
        
       
    }
}
