using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour{
    
    ChangeScene cs;
    OptionsMenu om;

    // Resetta la difficoltà del gioco
    /*void resetGame(){
        if(difficult != "Facile" || difficult != "Easy"){
            difficult = "Facile";
        }
    }
    public void volume(){
        OptionsMenu.Instance.UpdateVolume();
    }*/
    //Torna al menu principaòe
    public void backToMainMenu(){
        cs.changeLevel("MainMenu");
    }
}
