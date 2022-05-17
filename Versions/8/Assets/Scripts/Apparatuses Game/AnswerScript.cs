using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour{

    public QuizManager questionGenerator;
    private Color startColor;
    public bool isCorrect = false;
    
    public void Answer(){
        if(isCorrect){
            turnGreen();
            questionGenerator.correctAnswer();
        }
        else{
            turnRed();
            questionGenerator.wrongAnswer();
        }
    }

    // Default color
    public void initialColor(){
        startColor = this.GetComponentInParent<Image>().color;  
        this.GetComponentInParent<Image>().color = startColor;
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
