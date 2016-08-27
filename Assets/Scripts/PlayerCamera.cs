using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    private GameObject _myTarget;
    public float _xOffset;
    public float _yOffset;

    // Use this for initialization
    void Start()
    {
        _myTarget = FindObjectOfType<RunnyPig>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = _myTarget.transform.position;
        playerPos.x += _xOffset;
        playerPos.y = _yOffset;
        playerPos.z = -10;
        transform.position = playerPos;
    }
}
