using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject Enemy;
    private float maxSpawnRateInSeconds = 5f;

    // Start is called before the first frame update
    void Start(){
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        anEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn ();
    }

    void ScheduleNextEnemySpawn(){
        float spawnRateInSeconds;
        if(maxSpawnRateInSeconds > 1f){
            spawnRateInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else{
            spawnRateInSeconds = 1f;
        }
        Invoke("SpawnEnemy", spawnRateInSeconds);
    }

    void IncreaseSpawnRate(){
        if(maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;

        if(maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpwanRate"); 
    }
}
