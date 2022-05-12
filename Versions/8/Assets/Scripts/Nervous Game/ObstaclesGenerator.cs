using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour{
    public List<ObjectPooler> obstaclesPool;

    // Set distance between obstacles
    public float distanceBetweenMessage;
    public void SpawnObstacles(Vector3 startPosition){
        int valueRandom = (int)Random.Range(0f, obstaclesPool.Count);
        // Spawn message to center side
        GameObject obstacles = obstaclesPool[valueRandom].GetPooledObject();
        obstacles.transform.position = new Vector3(startPosition.x - Random.Range(-2.5f,+2.5f), startPosition.y + 0.1f, startPosition.z);
        obstacles.SetActive(true);
    }

}
