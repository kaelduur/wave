using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public GameObject player;
    public GameObject[] obstaclesArray;

    int playerDistanceIndex = -1;

    int obstacleCount;
    int obstacleIndex = 0;
    int distanceToNext = 30;

    void Start()
    {
        obstacleCount = obstaclesArray.Length;
        SpawnObstacle();
    }

    void Update()
    {
        int playerDistance = (int)(player.transform.position.y / (distanceToNext));
        // Debug.Log("playerDistance: " + playerDistance);

        if(playerDistanceIndex != playerDistance)
        {
            SpawnObstacle();
            playerDistanceIndex = playerDistance;
        }
    }

    public void SpawnObstacle()
    {
        int randomInt = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(obstaclesArray[randomInt], new Vector3(0, obstacleIndex * distanceToNext), Quaternion.identity);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;
    }
}
