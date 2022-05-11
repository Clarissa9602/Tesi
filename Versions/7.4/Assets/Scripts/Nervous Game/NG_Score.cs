using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NG_Score : MonoBehaviour
{
    private NG_GameManager manager;
    private static NG_Score _instance;
    private float countScore;
    
    public void Start()
    {
        countScore = 0;
        GetComponentInChildren<ScoreManager>().Score = (int)countScore;
        manager = FindObjectOfType<NG_GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        StartCoroutine("ScoreGame");
        if(countScore > 60){
            int nMessages = PickObject.instance.getPickedMessages();
            if(nMessages >= 5)
                manager.WinGame();
            else{
                countScore = 0;
                manager.GameNotCompleted.gameObject.SetActive(true);
                manager.GameOver();
            }
        }
    }
    // Increase score
    IEnumerator ScoreGame(){
        countScore += Time.deltaTime*5;
        GetComponentInChildren<ScoreManager>().Score = (int)Mathf.Round(countScore);
        yield return null;
    }

    public void setScore(){
        countScore = 0;
    }
    public static NG_Score instance
    {   
        get
        {
            return _instance;
        }
    }
}
