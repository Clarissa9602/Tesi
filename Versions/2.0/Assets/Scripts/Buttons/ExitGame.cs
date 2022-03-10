using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    ExitGame Instance;
    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Quit(){
        Application.Quit();

        // Esce dall'editor quando è in play
        // Simula l'uscita dal gioco
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
