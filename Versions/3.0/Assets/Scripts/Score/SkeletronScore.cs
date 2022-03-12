using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletronScore : MonoBehaviour{
    public List<GameObject> bones;

    public Text scoreText;
    int score;

    void Start(){
        score = 0;
    }

    void Update(){
        foreach(GameObject items in bones){
            checkPosition(items);
            //Debug.Log(items.name);
        }
        // Verifica posizione
        Debug.Log(score);
        scoreText.text = score + "%";
        if(score == 100)
            LoadingManager.Instance.LoadLevel("Main Menu");
    }
    void checkPosition(GameObject i){
        // Se l'item è stato trascinato nell'area corretta
        // Fisso l'item nel posto giusto 
        // E incremento lo score
        if(i.name == "Cranio")
            score += 20;
        /*if(i.name == "Torace")
        if(i.name == "Braccia")
        if(i.name == "Bacino")
        if(i.name == "Gambe")*/
    }
}
