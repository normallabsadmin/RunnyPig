using UnityEngine;
using System.Collections;

public class RunnyPig : MonoBehaviour {

    [Range(0f,10f)]
    public float _speed;
    public float _maxSpeed;
    public float _highJumpDelay = 0.1f;
    public float _longJumpDelay = 0.5f;
    public float _groundedDelay = 0.2f;


    public bool _onGround = true;
    public bool _isRunning;
    public bool _isJumping;
    public bool _isDucking;
    public bool _isDead;

    private Animator _myAnimator;

	// Use this for initialization
	void Start () {
        _myAnimator = GetComponent<Animator>();
	}
	
	void FixedUpdate()
    {

        if (!_isDead)
        {
            var currentSpeed = Mathf.Clamp(_speed, 0f, _maxSpeed);
            transform.Translate((Vector2.right * Time.deltaTime) * currentSpeed);
            #region jump controls
            //long jump
            if (Input.GetKey(KeyCode.UpArrow))
            {

                if (_onGround)
                {
                    _myAnimator.SetTrigger("WarmJump");
                    _onGround = false;
                }

                Invoke("HighJump", _highJumpDelay * Time.deltaTime);
                Invoke("LongJump", _longJumpDelay * Time.deltaTime);
            }
            #endregion

            #region ducking controls
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartDucking();
            }

            if (Input.GetKey(KeyCode.DownArrow))
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
        }
    }

    void HighJump()
    {
        if (!_isJumping && !Input.GetKey(KeyCode.UpArrow))
        {
            CancelInvoke();
            _isJumping = true;
            Debug.Log("High jump");
            _myAnimator.SetTrigger("HighJump");
        }
    }

    void LongJump()
    {
        if (!_isJumping)
        {
            CancelInvoke();
            _isJumping = true;
            Debug.Log("Low jump");
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

}


