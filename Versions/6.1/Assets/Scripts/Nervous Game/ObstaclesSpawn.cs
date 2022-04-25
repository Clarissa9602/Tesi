using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour{
    public Transform initialPos;
    public Transform endPos;
    public GameObject[] obstacles;
  
    public void ActivateObstacles(){
        DeactivateObstacles();
        int range = Random.Range(0,obstacles.Length);
        obstacles[range].SetActive(true);
    }
    public void DeactivateObstacles(){
        for(int i = 0; i < obstacles.Length; i++)
            obstacles[i].SetActive(false);
    }
}
