using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [Header("Scene Objects")]
    public Camera mainCamera;
    public GameObject roadTile;
    public GameObject sideTile;
    public GameObject roadParent;
    public GameObject leftTileParent;
    public GameObject rightTileParent;
    public GameObject playerCar;
    [Space(10)]

    [Header("Spawn Parameters")]
    //public int startingTiles = 5;
    public int tilesToSpawn = 10;
    public float movingSpeed = 10f;
    [Space(10)]

    [HideInInspector]
    float score = 0f;
    List<GameObject> spawnedRoadTiles = new List<GameObject>();
    List<GameObject> spawnedLeftTiles = new List<GameObject>();
    List<GameObject> spawnedRightTiles = new List<GameObject>();
    RoadTile roadTileScript;
    SideTile sideTileScript;
    Vector3 RoadLength;
    Vector3 RoadWidth;
    Vector3 TileWidth;

    void Awake(){
        roadTileScript = roadTile.GetComponent<RoadTile>();
        sideTileScript = sideTile.GetComponent<SideTile>();

        RoadLength = roadTileScript.endPos.position - roadTileScript.startPos.position;
        RoadWidth = roadTileScript.rightPos.position - roadTileScript.leftPos.position;
        TileWidth = sideTileScript.rightPos.position - sideTileScript.leftPos.position;
    }

    void Start(){
        StartSpawnRoads();
        StartObstacleSpawn();
        StartPlayCarSpawn();
    }

    void FixedUpdate()
    {
        
    }

    void StartSpawnRoads(){
        Vector3 curRoadSpawnPosition = Vector3.zero;

        for (int i = 0; i < tilesToSpawn; i++){
            GameObject spawnedRoad = Instantiate(roadTile, curRoadSpawnPosition, Quaternion.identity);
            spawnedRoad.transform.SetParent(roadParent.transform);
            spawnedRoadTiles.Add(spawnedRoad);

            Vector3 leftSpawnPos = curRoadSpawnPosition - (RoadWidth/2f) - (TileWidth/2f);
            GameObject spawnedLeft = Instantiate(sideTile, leftSpawnPos, Quaternion.identity);
            spawnedLeft.transform.SetParent(leftTileParent.transform);
            spawnedLeftTiles.Add(spawnedLeft);

            Vector3 rightSpawnPos = curRoadSpawnPosition + (RoadWidth/2f) + (TileWidth/2f);
            GameObject spawnedRight = Instantiate(sideTile, rightSpawnPos, Quaternion.identity);
            spawnedRight.transform.SetParent(rightTileParent.transform);
            spawnedRightTiles.Add(spawnedRight);

            curRoadSpawnPosition += RoadLength;
        }
    }

    void StartObstacleSpawn(){
        //discount a certain number of tiles and start spawning obstacle cars up till n-1 tiles
    }

    //Code to spawn player car on the road
    void StartPlayCarSpawn()
    {
        GameObject spawnedPlayerCar = Instantiate(playerCar, Vector3.zero, Quaternion.identity);
        Vector3 startPosition = Vector3.zero;
        startPosition.y += 1.26f;
        spawnedPlayerCar.transform.position = startPosition;
    }

    public GameObject returnPlayerCar()
    {
        return playerCar;
    }
}
