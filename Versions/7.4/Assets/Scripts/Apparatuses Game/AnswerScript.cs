using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour{

    public QuizManager questionGenerator;
    public bool isCorrect = false;
    
    public void Answer(){
        if(isCorrect){
            turnGreen();
            Debug.Log(this.gameObject.name);
            questionGenerator.correctAnswer();
        }
        else{
            turnRed();
            Debug.Log(this.gameObject.name);
            questionGenerator.wrongAnswer();
        }
    }

    // Default color
    public void turnYellow(){
        Color yellow = this.GetComponentInParent<Image>().color;  
        yellow = new Color32(255,243,0,255);
        this.GetComponentInParent<Image>().color = yellow;
    }
    // Wrong color answer
    private void turnRed(){
        Color red = this.GetComponentInParent<Image>().color;  
        red = new Color32(255, 100, 100, 255);
        this.GetComponentInParent<Image>().color = red;
    }

    // Correct color answer
    private void turnGreen(){
        Color green = this.GetComponentInParent<Image>().color;  
        green = new Color32(33,255,0,255);
        this.GetComponentInParent<Image>().color = green;
    }
}
