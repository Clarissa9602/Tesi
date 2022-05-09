using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_GameManager: MonoBehaviour{

    public GameObject btnPlay;
    public GameObject UIPlayer;
    public GameObject GamePlay;

    public GameObject GameCompleted;
    public GameObject gameOver;
    //public GameObject questionGenerator;
    public GameObject Title;
    //private Text scoreText;

    public void StartGame(){
        UIPlayer.SetActive(true);
        UIPlayer.GetComponentInChildren<MG_Score>().setScore();
        //questionGenerator.SetActive(true);
        GamePlay.SetActive(true);
        btnPlay.SetActive(false);
        Title.SetActive(false);
    }

    // Try again after loose
    public void TryAgain(){
        gameOver.SetActive(false);
        btnPlay.SetActive(true);
        Title.SetActive(true);
        
    }
    // End of game
    public void GameOver(){
        UIPlayer.SetActive(false);  
        gameOver.SetActive(true);
        //questionGenerator.SetActive(false);
        UIPlayer.SetActive(true);
        Invoke("TryAgain", 8f);       
    }
    
    // Win
    public void WinGame(){
       
        GameCompleted.SetActive(true);
       
        Destroy(FindObjectOfType<MG_Score>().gameObject);
        StopCoroutine("ScoreGame");
        
    }
}
