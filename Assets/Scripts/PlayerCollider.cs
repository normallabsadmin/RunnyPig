using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public ScoreManager _scoreManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<ScoreMarker>())
        {
            _scoreManager._myScore++;
            Destroy(col.gameObject);
        }
        else
        {
            transform.parent.GetComponent<RunnyPig>().PlayerDie();
        }
        
    }
}
