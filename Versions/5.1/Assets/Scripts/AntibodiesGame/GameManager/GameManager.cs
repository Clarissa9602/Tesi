using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public GameObject playerShip;
    public GameObject enemySpawner;
    //public GameObject scoreUITextGO;
    public GameObject UIScore;
    public GameObject UIOpening;

    public GameObject gameOver;
    public GameObject waves;
    private int numberWave;

    public enum GameManagerState{
        Opening,
        Gameplay,
        GameOver,
    }


    GameManagerState GMState;
    // Start is called before the first frame update
    void Start(){
        GMState = GameManagerState.Opening;
        UpdateGameManagerState();
    }
    // Aggiorna lo stato del game manager
    void UpdateGameManagerState(){
        switch(GMState){
            case GameManagerState.Opening:
                UIScore.SetActive(false);
                UIOpening.SetActive(true);
                gameOver.SetActive(false);
                break;
            case GameManagerState.Gameplay:
                UIScore.SetActive(true);
                UIOpening.SetActive(false);
                UIScore.GetComponentInChildren<AntibodiesScore>().Score = 0;
                waves.SetActive(true);
                waves.GetComponent<Waves>().gameWaves(0);
                
                playerShip.GetComponent<PlayerController>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawn();
                
                break;
            case GameManagerState.GameOver:
                gameOver.SetActive(true);          
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }

    // Permette di modificare lo stato del game manager
    public void SetGameManagerState(GameManagerState state){
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay(){
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
    public void StopGamePlay(){
        // Da sostituire con una schermata di gioco completato
        GMState = GameManagerState.GameOver;
        UpdateGameManagerState();
    }
    public void ChangeToOpeningState(){
        SetGameManagerState(GameManagerState.Opening);
        UpdateGameManagerState();
    }
}
