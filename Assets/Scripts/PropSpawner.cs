using UnityEngine;
using System.Collections;

public class PropSpawner : MonoBehaviour {

    public GameObject _floorPrefab;
    public GameObject _floorBoss;
    public float nextFloorSpawnTime;

    private float _nextX = 3f * 2;

    public GameObject[] _obstacles;
    public float _obOriginX = 9f;
    public float _obNextX;

    public Transform bin;


    public void SpawnFloor()
    {
        var floorPos = transform.position;
        floorPos.x = _nextX;
        floorPos.y = -2;
        var newFloor = (GameObject)Instantiate(_floorPrefab, floorPos, Quaternion.identity);
        newFloor.transform.parent = _floorBoss.transform;

        _nextX = _nextX + 3f;
        Invoke("SpawnFloor", nextFloorSpawnTime * Time.deltaTime);
    }

    public void SpawnObstacle( )
    {
       
        var randomOb = (int)Random.Range(0f, _obstacles.Length);
        var newPos = new Vector2(_obNextX, 0f);
        var newOb = (GameObject)Instantiate(_obstacles[randomOb], newPos, Quaternion.identity);
        newOb.GetComponent<ObstacleCluster>()._spawnMaster = gameObject;
        newOb.transform.parent = bin;
        Invoke("SpawnObstacle", (nextFloorSpawnTime * Time.deltaTime) * 2);
    }

    void Start()
    {
        SpawnFloor();
        _obNextX = _obOriginX;
        SpawnObstacle();
    }
}
