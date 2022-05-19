using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSuccession : MonoBehaviour
{
    private DialogueManager dM;
    public GameObject obj;
    void Start(){
        // Trova il Dialogue Manager
        dM = FindObjectOfType<DialogueManager>();
    }
    public void nextEvent(){
        // Se il dialogo è terminato procedi con l'attivazione della canvas successiva
        if(dM.finishDialogue == true){
            dM.finishDialogue = false;
            obj.SetActive(true);
            //this.gameObject.SetActive(false);
        }
    }
}
