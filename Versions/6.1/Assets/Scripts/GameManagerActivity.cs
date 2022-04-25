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
                break;
            case GameManagerState.Gameplay:
                //selectType(type.name);
                break;
            case GameManagerState.GameOver:
                break;
        }
    }

    public void SelectSystem(){
        nameType = ChooseSystem.Instance.systemType.text;
        switch(nameType){
            case "Sistema Scheletrico":
                LoadingManager.Instance.LoadLevel("Activity 2A");
            break;
            case "Sistema Muscolare":
                LoadingManager.Instance.LoadLevel("Activity 2B");
            break;
            case "Sistema Nervoso":
                LoadingManager.Instance.LoadLevel("Activity 2C");
            break;
            case "Sistema Linfatico":
                LoadingManager.Instance.LoadLevel("Activity 2D");
            break;
        }  
    }
}
