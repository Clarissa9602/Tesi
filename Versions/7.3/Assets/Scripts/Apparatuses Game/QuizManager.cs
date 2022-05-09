using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour{
    
    public List<QuestionAndAnswer> questions;
    public GameObject[] options;

    public Text questTextUI, scoreText, timerText, lifeText;
    public List<Image> imageLife;
    
    private int randomIndex;
    private int totQuest, score, life;
    public int maxLifes;

    public Text ScoreText{get{return scoreText;}}
    public Text TimerText{get{return timerText;}}
    private void Start(){
        
        randomIndex = 0;
        totQuest = questions.Count;
        life = maxLifes;
        score = 0;
        scoreText.text = "Score" + score;
        lifeText.text = "Life: "+life;
        
    }

    private void setAnswer(){
        for(int i = 0; i < options.Length; i++){
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = questions[randomIndex].Answers[i];
            if(questions[randomIndex].CorrectAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    private void resetColor(){
        for(int i = 0; i < options.Length; i++){
            options[i].GetComponent<AnswerScript>().turnYellow();
        }
    }

    public void generateQuestion(){
        // If there are questions generate next
        if(questions.Count > 0){
            randomIndex = Random.Range(0, questions.Count);
            questTextUI.text = questions[randomIndex].Question;
            
            setAnswer();
            //resetColor();
        }
        else{
            // Retry
        }
        
    }

    public void correctAnswer(){
        score++;
        Debug.Log("Score " + score);
        scoreText.text = "Score: "+score;
        questions.RemoveAt(randomIndex);
        generateQuestion();
    }

    public void wrongAnswer(){
        life--;
        //questions.RemoveAt(randomIndex);
        generateQuestion();
    }

}
