using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NG_GameManager: MonoBehaviour{
    private GameObject player;
    public Vector3 playerStartPosition;
    public Vector3 platformStartPosition;
    public Vector3 messagesStartPosition;
    public Vector3 obstaclesStartPosition;

    public Camera mainCamera;
    //public GameObject platformGen;
    public GameObject playerPrefab;
    public GameObject btnPlay;
    public GameObject UIScore;
    public GameObject GameCompleted;
    public GameObject GameNotCompleted;
    public GameObject gameOver;
    public GameObject platformGenerator;
    public GameObject messagesGenerator;
    public GameObject obstaclesGenerator;
    public GameObject Title;
    private Text scoreText;

    public void StartGame(){
        UIScore.SetActive(true);
        UIScore.GetComponentInChildren<NG_Score>().setScore();

        if(player == null)
            player = Instantiate(playerPrefab);
        else{
            player.SetActive(true);
            player.GetComponent<NG_PlayerController>().SetInfo();
        }
        platformStartPosition = platformGenerator.transform.position;
        
        messagesStartPosition = messagesGenerator.GetComponentInChildren<ObjectPooler>().transform.position;
        obstaclesStartPosition = obstaclesGenerator.GetComponentInChildren<ObjectPooler>().transform.position;


        platformGenerator.SetActive(true);
        messagesGenerator.SetActive(true);
        messagesGenerator.GetComponentInChildren<ObjectPooler>().gameObject.SetActive(true);
        obstaclesGenerator.SetActive(true);

    }

    // Try again after loose
    public void TryAgain(){
        
        if(GameNotCompleted.activeInHierarchy){
            GameNotCompleted.SetActive(false);
        }
        platformGenerator.transform.position = platformStartPosition;
        messagesGenerator.transform.position = messagesStartPosition;
        obstaclesGenerator.transform.position = obstaclesStartPosition;
        gameOver.SetActive(false);
        btnPlay.SetActive(true);
        Title.SetActive(true);
        
    }
    // End of game
    public void GameOver(){
        TilesDestroyer[] allObjects = GameObject.FindObjectsOfType<TilesDestroyer>();
        foreach(TilesDestroyer obj in allObjects) {
            obj.gameObject.SetActive(false);
            //Destroy(obj.gameObject);
        }
        mainCamera.gameObject.SetActive(true);

        UIScore.SetActive(false);  
        gameOver.SetActive(true);
        platformGenerator.SetActive(false);
        messagesGenerator.SetActive(false);
        obstaclesGenerator.SetActive(false);
        player.SetActive(false);

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
