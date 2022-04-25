using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour{
    public GameObject boss;
    void Start(){
        SpawnBoss();
    }
    
    public void SpawnBoss(){
        boss = Instantiate(boss);
    }
    public void KilledBoss(){
        Destroy(boss.GetComponent<BossController>().gameObject);
    }

}
