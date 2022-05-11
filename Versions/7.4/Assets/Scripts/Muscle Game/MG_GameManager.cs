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
    public GameObject Title;

    public void StartGame(){
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
        GamePlay.SetActive(false);
        gameOver.SetActive(true);
        //Invoke("TryAgain", 8f);       
    }
    
    // Win
    public void WinGame(){
       
        GameCompleted.SetActive(true);
       
        Destroy(FindObjectOfType<MG_Score>().gameObject);
        StopCoroutine("ScoreGame");
        
    }
}
