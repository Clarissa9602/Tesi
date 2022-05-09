using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletronScore : MonoBehaviour{
    private static SkeletronScore instance;
    [SerializeField]
    private GameObject winText;
    public Text scoreText;
    public static int score;

    void Awake(){
        score = 0;
        instance = this;
        scoreText.text = score.ToString() + "%";
    }
    void Start(){
        winText.SetActive(false);
    }

    // Trasformare in una coroutine che si stoppa quando il gioco è completo
    void Update(){
        if( Arms.locked &&
            Head.locked && 
            Legs.locked &&
            Chest.locked && 
            HipBones.locked && score == 100){
            winText.SetActive(true);
        }
    }

    public static SkeletronScore Instance{
        get
        {
            return instance;
        }
    }
    public void AddPoint(){
        score += 20;
        scoreText.text = score.ToString() + "%";               
    }
}
