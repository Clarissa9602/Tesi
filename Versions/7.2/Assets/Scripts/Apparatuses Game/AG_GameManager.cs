using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_GameManager: MonoBehaviour{

    public GameObject btnPlay;
    public GameObject UIScore;
    public GameObject GameCompleted;
    public GameObject gameOver;
    public GameObject questionGenerator;
    public GameObject Title;
    private Text scoreText;

    public void StartGame(){
        UIScore.SetActive(true);
        UIScore.GetComponentInChildren<MG_Score>().setScore();
        questionGenerator.SetActive(true);
    }

    // Try again after loose
    public void TryAgain(){
        gameOver.SetActive(false);
        btnPlay.SetActive(true);
        Title.SetActive(true);
        
    }
    // End of game
    public void GameOver(){
        UIScore.SetActive(false);  
        gameOver.SetActive(true);
        questionGenerator.SetActive(false);
        UIScore.SetActive(true);
        Invoke("TryAgain", 8f);       
    }
    
    // Win
    public void WinGame(){
       
        GameCompleted.SetActive(true);
       
        Destroy(FindObjectOfType<MG_Score>().gameObject);
        StopCoroutine("ScoreGame");
        
    }
}
