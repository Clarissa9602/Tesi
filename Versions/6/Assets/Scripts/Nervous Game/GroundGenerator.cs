using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator: MonoBehaviour{
    
    public Camera mainCamera;
    public GameObject player;
    public GameObject btnPlay;
    public GameObject gameOver;
    public Transform floor;
    private Vector3 nextFloor;
    
    // Start is called before the first frame update
    void Start(){
        nextFloor.z = 70;
    }
    void spawnFloor(){
        //yield return new WaitForSeconds(1);
        Instantiate(floor, nextFloor, floor.rotation);
        nextFloor.z += 10;
        InvokeRepeating("spawnFloor", 3, 1);
    }

    public void StartGame(){
        mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 6);
        Instantiate(player);
        Invoke("spawnFloor", 1);
    }
    
    public void TryAgain(){
        gameOver.SetActive(false);
        btnPlay.SetActive(true);
    }
    public void GameOver(){
        mainCamera.gameObject.SetActive(true);
        mainCamera.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameOver.SetActive(true);
        CancelInvoke("spawnFloor");
        ObstaclesSpawn[] spawnTiles = FindObjectsOfType<ObstaclesSpawn>();
        for(int i = 0; i < spawnTiles.Length; i++)
            Destroy(spawnTiles[i]);
        Invoke("TryAgain", 8f);
    }
}
