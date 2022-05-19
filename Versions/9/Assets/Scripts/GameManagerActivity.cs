using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerActivity : MonoBehaviour{
    public GameObject chooseSystem;
    private string nameType;
    public enum GameManagerState{
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;
    // Start is called before the first frame update
    void Start(){
        GMState = GameManagerState.Opening;
        UpdateGameManagerState();
        //ChangeToOpeningState();
    }
     void UpdateGameManagerState(){
        switch(GMState){
            case GameManagerState.Opening:
            // Here needs to add dialog UI
                break;
            case GameManagerState.Gameplay:
                SelectSystem();
                break;
            /*case GameManagerState.GameOver:
                // We don't need of it for now
                break;*/
        }
    }

    public void SelectSystem(){
        nameType = ChooseSystem.Instance.systemType.text;
        switch(nameType){
            case "Sistema Scheletrico":
                LoadingManager.Instance.LoadLevel("Skeleton Game");
            break;
            case "Sistema Nervoso":
                LoadingManager.Instance.LoadLevel("Nervous Game");
            break;
            case "Sistema Muscolare":
                LoadingManager.Instance.LoadLevel("Muscle Game");
            break;
            case "Sistema Linfatico":
                LoadingManager.Instance.LoadLevel("Antibodies Game");
            break;
        }  
    }
}
