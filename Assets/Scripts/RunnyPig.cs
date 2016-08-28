using UnityEngine;
using System.Collections;

public class RunnyPig : MonoBehaviour {

    public GameManager _gameManager;

    [Range(0f,10f)]
    public float _speed;
    public float _startingSpeed = 3.5f;
    public float _maxSpeed;
    public float _highJumpDelay = 0.1f;
    public float _longJumpDelay = 0.5f;
    public float _groundedDelay = 0.2f;


    public bool _onGround = true;
    public bool _isRunning;
    public bool _isJumping;
    public bool _isDucking;
    public bool _isDead;

    private int _activeSkin = PlayerPrefs.GetInt("ActiveCharacter");
    private int _lastActiveSkin = 0;

    private Animator _myAnimator;

	// Use this for initialization
	void Start () {
        _myAnimator = GetComponent<Animator>();
	}

    public void StartGame()
    {
        _speed = _startingSpeed;
        _myAnimator.SetBool("isStanding", false);
    }
	
	void FixedUpdate()
    {

        if(_lastActiveSkin != _activeSkin)
        {
            ChangeSkin();
            _lastActiveSkin = _activeSkin;
        }

        if(_speed == 0)
        {
            _myAnimator.SetBool("isStanding", true);
        }else
        {
            _myAnimator.SetBool("isStanding", false);
        }


        if (!_isDead)
        {
            var currentSpeed = Mathf.Clamp(_speed, 0f, _maxSpeed);
            transform.Translate((Vector2.right * Time.deltaTime) * currentSpeed);
            #region jump controls
            if (Input.GetKey(KeyCode.UpArrow))
            {
                InputJump();
            }
            #endregion

            #region ducking controls
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                StartDucking();
            }
            else
            {
                StopDucking();
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                StopDucking();
            }
            #endregion

            #region touch controls
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.y > Screen.height / 2)
                {
                    InputJump();
                }
                else if (touch.position.y < Screen.height / 2)
                {
                    StartDucking();
                }
                else
                {
                    StopDucking();
                }
            }
            #endregion
        }
    }

    void InputJump()
    {

        if (_onGround)
        {
            LongJump();
        }

        /*
        if (_onGround)
        {
            _myAnimator.SetTrigger("WarmJump");
            _onGround = false;
        }
        //Mobile version is having trouble with the high jump so we're taking it away for now
        //Invoke("HighJump", _highJumpDelay * Time.deltaTime);
        Invoke("LongJump", _longJumpDelay * Time.deltaTime);
        */
    }

    void HighJump()
    {
        if (!_isJumping && !Input.GetKey(KeyCode.UpArrow))
        {
           
        }
        else if (!_isJumping && 
           (
               (Input.touchCount <= 0) ||
               ((Input.touchCount > 0) && (Input.GetTouch(0).position.y > Screen.height / 2))
            )
        )
        {
            var touch = Input.GetTouch(0);
            if (touch.position.y < Screen.height / 2)
            {
                CancelInvoke();
                _isJumping = true;
                Debug.Log("High jump");
                _myAnimator.SetTrigger("HighJump");
            }
        }
    }

    void LongJump()
    {
        if (!_isJumping)
        {
           // CancelInvoke();
            _isJumping = true;
            //Debug.Log("Low jump");
            _myAnimator.SetTrigger("LowJump");
        }
    }

    public void HitGround()
    {
        //Debug.Log("Hit Ground");
        
        Invoke("GroundedDelay", _groundedDelay);
    }

    private void GroundedDelay()
    {
        _isJumping = false;
        _onGround = true;
    }

    void StopDucking()
    {
        _isDucking = false;
        _myAnimator.SetBool("isDucking", false);
    }

    void StartDucking()
    {
        _isDucking = true;
        _myAnimator.SetBool("isDucking", true);
    }

    public void PlayerDie()
    {
        _myAnimator.SetBool("isDead", true);
        _speed = 0f;
        _isDead = true;
    }

    public void PlayerEndGame()
    {
        _gameManager.EndGame();
    }

    public void ChangeSkin()
    {

    }

}


