using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    // Instance of the enemy prefab
    public List<GameObject> Enemies;
    private float maxSpawnRateInSeconds = 5f;
    private int range;
    void Start(){
        SpawnEnemy();
    }
    
    void SpawnEnemy(){
        range = Random.Range(0,Enemies.Count);
        // Set min coordinates about the screen
        // Bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        // Bottom-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        // Create a new istance of enemy
        GameObject anEnemy = (GameObject)Instantiate(Enemies[range]);
        // Compute random position and give him
        anEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn(){
        // This method decide when an enemy will be istantiate
        float spawnRateInSeconds;

        if(maxSpawnRateInSeconds > 1f){
            // It's a value between 1 and maxSpawnRateInSeconds
            spawnRateInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else{
            spawnRateInSeconds = 1f;
        }
        Invoke("SpawnEnemy", spawnRateInSeconds);
    }


    public void ScheduleEnemySpawn(){
        // Spawn the enemy every maxSpawnRateInSeconds seconds
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
    }
    public void UnscheduleEnemySpawner(){
        CancelInvoke("SpawnEnemy");
    }
}
