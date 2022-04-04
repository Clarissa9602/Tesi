using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTypeModels : MonoBehaviour
{
    public Text t1;
    public GameObject systemModel;
    public void shows(){
        switch(t1.text){
            case "Sistema Scheletrico":
                //systemModel.gameObject.setActive(true);
            break;
            case "Sistema Muscolare":
                Debug.Log("Sistema muscolare");
            break;
            case "Sistema Nervoso":
                Debug.Log("Sistema nervoso");
            break;
        }
    }
}
