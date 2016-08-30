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

    private int _suckerCoolDown;


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

        int adjustedLen;
        //suckers need a cool down period
        // at zero it's okay to spawn a sucker again
        if(_suckerCoolDown > 0)
        {
            adjustedLen = _obstacles.Length - 4;
        }
        else
        {
            adjustedLen = _obstacles.Length;
        }

        var randomOb = (int)Random.Range(0f, adjustedLen); 

        //if we do spawn a sucker set the cool down period
        if(randomOb >= 6)
        {
            _suckerCoolDown = 3;
        }

        var newPos = new Vector2(_obNextX, 0f);
        var newOb = (GameObject)Instantiate(_obstacles[randomOb], newPos, Quaternion.identity);
        newOb.GetComponent<ObstacleCluster>()._spawnMaster = gameObject;
        newOb.transform.parent = bin;
        Invoke("SpawnObstacle", (nextFloorSpawnTime * Time.deltaTime) * 2);

        _suckerCoolDown--;
        if(_suckerCoolDown < 0)
        {
            _suckerCoolDown = 0;
        }


    }

    void Start()
    {
        SpawnFloor();
        _obNextX = _obOriginX;
        SpawnObstacle();
    }
}
