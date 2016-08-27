using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	private void OnTriggerExit2D(Collider2D col)
    {
        Destroy(col.gameObject);
    }
}
