using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletronScore : MonoBehaviour{
    public Text scoreText;
    int score;

    void Start(){
        score = 0;
    }

    void Update(){
        scoreText.text = score + "%";
    }
}
