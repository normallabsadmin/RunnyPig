using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.parent.GetComponent<RunnyPig>().PlayerDie();
    }
}
