using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour{
    public GameObject boss;
    private BossController finalBoss;
    void Start(){
        finalBoss = new BossController();
        
        SpawnBoss();
    }
    
    public void SpawnBoss(){
        boss = Instantiate(boss);
        if(!boss.activeInHierarchy){
            boss.SetActive(true);
            boss = finalBoss.GetComponentInParent<BossSpawner>().gameObject;
        }
           
        
    }

    public void KilledBoss(){
       boss.SetActive(false);
    }

}
