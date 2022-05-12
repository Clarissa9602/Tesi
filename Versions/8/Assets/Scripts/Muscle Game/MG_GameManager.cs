using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_GameManager: MonoBehaviour{

    public GameObject btnPlay;
    public GameObject UIPlayer;
    public GameObject GamePlay;

    public GameObject GameCompleted;
    public GameObject Title;

    private Text gameText;

    public void StartGame(){
        GamePlay.SetActive(true);
        btnPlay.SetActive(false);
        Title.SetActive(false);

        gameText = GameCompleted.GetComponentInChildren<Text>();
    }

    // Try again after loose
    public void TryAgain(){
        GameCompleted.SetActive(false);
        btnPlay.SetActive(true);
        Title.SetActive(true);
        
    }
    // End of game
    public void GameOver(){
        gameText.text = "Hai perso";
        UIPlayer.SetActive(false);
        GamePlay.SetActive(false);
        GameCompleted.SetActive(true);     
    }
    
    // Win
    public void WinGame(){
        gameText.text = "Hai vinto";
        GamePlay.SetActive(false);
        GameCompleted.SetActive(true);
    }
}
