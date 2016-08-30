using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
