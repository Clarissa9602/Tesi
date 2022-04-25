using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NG_GameManager: MonoBehaviour{
    
    public Camera mainCamera;
    //public GameObject platformGen;
    public GameObject playerPrefab;
    private GameObject player;
    public GameObject btnPlay;
    public GameObject UIScore;
    public GameObject GameCompleted;
    public GameObject GameNotCompleted;
    public GameObject gameOver;
    public List<GameObject> messages;
    private Text scoreText;

    public void StartGame(){
        UIScore.SetActive(true);
        player = Instantiate(playerPrefab);
        
    }

    // Try again after loose
    public void TryAgain(){
        if(GameNotCompleted.activeInHierarchy)
            GameNotCompleted.SetActive(false);
        
        gameOver.SetActive(false);
        btnPlay.SetActive(true);
        
        foreach(GameObject mex in messages)
            mex.SetActive(true);
    }
    // End of game
    public void GameOver(){
        //platformGen.SetActive(false);
        UIScore.SetActive(false);  
        mainCamera.gameObject.SetActive(true);
       
        gameOver.SetActive(true);
        //CancelInvoke("spawnFloor");
        Destroy(player);
        Invoke("TryAgain", 8f);
    }
    
    // Win
    public void WinGame(){
       
        GameCompleted.SetActive(true);
       
        Destroy(FindObjectOfType<NG_Score>().gameObject);
        StopCoroutine("ScoreGame");
        
        FindObjectOfType<NG_PlayerController>().gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
