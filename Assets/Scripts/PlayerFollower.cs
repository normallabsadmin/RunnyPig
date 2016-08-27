using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour {

    private GameObject _myTarget;
    public float _xOffset;
 


    // Use this for initialization
    void Start () {
        _myTarget = FindObjectOfType<RunnyPig>().gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var playerPos = _myTarget.transform.position;
        playerPos.x += _xOffset;
        playerPos.y = 0 ;
        playerPos.z = 0;
        transform.position =  playerPos;
	}
}
