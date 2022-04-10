using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntibodiesScore : MonoBehaviour{
    public Text scoreTextUI;
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
   
    // Start is called before the first frame update
   
    void Start(){
        score = 0;
        scoreTextUI = GetComponent<Text>(); 
    }

    void UpdateScoreTextUI(){
        scoreTextUI.text = "Score: " + score;
    }
}
