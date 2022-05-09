using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour{

    public QuizManager questionGenerator;
    public bool isCorrect = false;
    public void Answer(){
        Debug.Log("Set color");
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
    public void turnYellow(){
        Color color = this.GetComponentInParent<Image>().color;  
        color = new Color32(255,243,0,255);
        this.GetComponentInParent<Image>().color = color;
    }
    // Wrong color answer
    private void turnRed(){
        Color color = this.GetComponentInParent<Image>().color;  
        color = new Color32(255, 100, 100, 255);
        this.GetComponentInParent<Image>().color = color;

        /* To use when game finish
        for(int i = 0; i < options.Length; i++){
            if(i != randomIndex){
                Color color = options[i].GetComponentInParent<Image>().color;
                color = new Color32(255, 100, 100, 255);
                options[i].GetComponentInParent<Image>().color = color;
            }
        }*/
    }
    // Correct color answer
    private void turnGreen(){
        Color color = this.GetComponentInParent<Image>().color;  
        color = new Color32(33,255,0,255);
        this.GetComponentInParent<Image>().color = color;
    }
}
