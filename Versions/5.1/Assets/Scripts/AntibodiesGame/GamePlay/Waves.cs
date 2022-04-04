using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour{
    public List<GameObject> waves;
    public GameObject WaveManager;
    private int numberWave;
    private int scoreRecord;
    private float timerWave;

    private void Start(){
        numberWave = 0;
    }
    private void Update(){
        if(numberWave < 3){
            if(timerWave > 0){
                timerWave -= Time.deltaTime;
            }
            else{
                numberWave++;
                gameWaves(numberWave);
                
            }
        }
    }

    public void gameWaves(int number){
        waves[number].SetActive(true);
        // 3 ondate di gioco in tutto
        switch(number){
            // Prima ondata, i nemici saranno solo le micosi
            case 0:
                Debug.Log("Prima ondata" + number);
                timerWave = 10;
                /*if((int)timerWave == 0){
                    number++;
                    Debug.Log("Next " + number);
                }*/
                /*scoreRecord = 75;
                if(timerWave <= 0){
                    number++;
                    waves[number-1].SetActive(false);
                    waves[number].SetActive(true);
                }*/
                break;
            // Seconda ondata, i nemici saranno micosi e batteri
            case 1:
                WaveManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.SecondWave);
                
                Debug.Log("Seconda ondata");
                waves[number-1].SetActive(false);
                timerWave = 15;
                
                
                //scoreRecord = 300;
               
                break;
            // Terza ondata, i nemici saranno micosi, batteri e virus
            case 2:
                Debug.Log("Terza ondata");
                WaveManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.ThirdWave);
                timerWave = 30;
                waves[number-1].SetActive(false);
                
                /*
                scoreRecord = 545;*/
                break;
            // Boss finale
           /* case 3:
                Debug.Log("Boss finale");
                waves[number-1].SetActive(false);
                timerWave = 60;
                break;*/
        } 
    }
}
