using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    //public GameObject playerShip;
    //public List<GameObject> enemySpawner;
    public GameObject UIScore;
    public GameObject FinalScore;
    public GameObject UIOpening;
     public GameObject UIWin;

    public GameObject gameOver;
    public GameObject waves;

    public enum GameManagerState{
        Opening,
        Gameplay,
        GameOver,
        Completed
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
                UIWin.SetActive(false);
                break;
            case GameManagerState.Gameplay:
                UIOpening.SetActive(false);
                waves.SetActive(true);
                waves.GetComponent<Waves>().playAgain();
                UIScore.SetActive(true);
                UIScore.GetComponentInChildren<ScoreManager>().Score = 0;
                break;
            case GameManagerState.GameOver:
                gameOver.SetActive(true);
                int i1 = waves.GetComponent<Waves>().getNWaves();
                waves.GetComponent<Waves>().StopPlayer();
                waves.GetComponent<Waves>().StopEnemies(i1);
                waves.SetActive(false);
                UIScore.SetActive(false);
                Invoke("ChangeToOpeningState", 8f);
                break;
            case GameManagerState.Completed:
                int i2 = waves.GetComponent<Waves>().getNWaves();
                waves.GetComponent<Waves>().StopPlayer();
                waves.GetComponent<Waves>().StopEnemies(i2);
                waves.SetActive(false);
                UIScore.SetActive(false);
                UIWin.SetActive(true);      
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
    public void ChangeToOpeningState(){
        SetGameManagerState(GameManagerState.Opening);
        UpdateGameManagerState();
    }
}
