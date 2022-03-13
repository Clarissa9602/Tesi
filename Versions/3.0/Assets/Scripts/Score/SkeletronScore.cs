using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletronScore : MonoBehaviour{
    public static SkeletronScore Instance;
    public List<GameObject> bones;

    public Text scoreText;
    int score;

    void Awake(){
        Instance = this;
    }
    void Start(){
        score = 0;
        scoreText.text = score.ToString() + "%";
    }

    public void checkPosition(GameObject i){
        // Se l'item è stato trascinato nell'area corretta
        // Fisso l'item nel posto giusto 
        // E incremento lo score
        //if(i.name == "Cranio")
            score += 20;
        scoreText.text = score.ToString() + "%";
        /*if(i.name == "Torace")
        if(i.name == "Braccia")
        if(i.name == "Bacino")
        if(i.name == "Gambe")*/
    }
}
