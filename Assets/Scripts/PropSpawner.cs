using UnityEngine;
using System.Collections;

public class PropSpawner : MonoBehaviour {

    public GameObject _floorPrefab;
    public GameObject _floorBoss;
    public float nextFloorSpawnTime;

    private float _nextX = 3f * 2;


    public void SpawnFloor()
    {
        var floorPos = transform.position;
        floorPos.x = _nextX;
        floorPos.y = -2;
        var newFloor = (GameObject)Instantiate(_floorPrefab, floorPos, Quaternion.identity);
        newFloor.transform.parent = _floorBoss.transform;

        _nextX = _nextX + 3f;
        Invoke("SpawnFloor", nextFloorSpawnTime);
    }

    void Start()
    {
        SpawnFloor();
    }
}
