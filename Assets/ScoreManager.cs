using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int _myScore;
    private int _previousScore;
    public Sprite[] _numberSprites;
    public SpriteRenderer _ones;
    public SpriteRenderer _tens;
    public SpriteRenderer _hundreds;

    void Start()
    {
        _ones.sprite = _numberSprites[_myScore];
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
            gameManager._timeScaleMulti = 1 + ((float)_myScore/20);

            _previousScore = _myScore;

        }
        
       
    }
}
