using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour{
    
    public MG_GameManager gameManag;
    public LifeManager lifeManag;
    public ScoreManager scoreManag;
    public List<QuestionAndAnswer> questions;
    public GameObject[] options;

    public Text questTextUI, timerText;

    private int randomIndex;
    private int totQuest, score;

    public Text TimerText{get{return timerText;}}
    
    private void Start(){
        randomIndex = 0;
        totQuest = questions.Count;
        //scoreManag.Score = 0;     
    }

    public void generate(){
        StartCoroutine(generateQuestion());
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
            options[i].GetComponent<AnswerScript>().initialColor();
        }
    }

    IEnumerator generateQuestion(){
        // If there are questions generate next
        yield return new WaitForSeconds(1.5f);
        if(questions.Count > 0){
            randomIndex = Random.Range(0, questions.Count);
            questTextUI.text = questions[randomIndex].Question;

            setAnswer();
            resetColor();
        } 
    }

    public void correctAnswer(){
        scoreManag.Score++;
        //scoreText.text = "Score: "+score;
        if(scoreManag.Score == scoreManag.maxScore)
            FindObjectOfType<MG_GameManager>().WinGame();
        else{
            questions.RemoveAt(randomIndex);
            generate();
        }
        
    }

    public void wrongAnswer(){
        lifeManag.TakeDamage(1);
        generate();
    }

}