using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour{    
    public Text timerText;
    public float timeRemaining;
    public bool timerIsRunning = false;
    private float seconds;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    
    private void Update(){
        timerText.text = "Timer: " + seconds;
        if (timerIsRunning){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
                seconds = Mathf.FloorToInt(timeRemaining % 60); 
            }
            else{
                timeRemaining = 0;
                timerIsRunning = false;
                FindObjectOfType<MG_GameManager>().GameOver();
            }     
        }
    }
}