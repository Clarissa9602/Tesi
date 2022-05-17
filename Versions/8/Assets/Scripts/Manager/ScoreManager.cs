using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour{
    private static ScoreManager _instance;
    public Text scoreTextUI;
    public int maxScore;
    private int score;

    public int Score{
       get{
           return this.score;
       }
       set{
           this.score = value;
           UpdateScoreTextUI();
       }
    }
    public static ScoreManager instance
    {
        get
        {
            return _instance;
        }
    }
   
    // Start is called before the first frame update
   
    private void Start(){
        _instance = this;
        score = 0;  
    }

    private void UpdateScoreTextUI(){
        scoreTextUI.text = "Score: " + score;
        if(score == maxScore)
            win();
    }

    private void win(){
        FindObjectOfType<MG_GameManager>().WinGame();
    }
}