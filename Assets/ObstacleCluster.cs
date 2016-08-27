using UnityEngine;
using System.Collections;

public class ObstacleCluster : MonoBehaviour {

    public float _spawnFootSpace = 1f;
    public GameObject _spawnMaster;

    void Start()
    {
        _spawnMaster.GetComponent<PropSpawner>()._obNextX += _spawnFootSpace;
    }
}
