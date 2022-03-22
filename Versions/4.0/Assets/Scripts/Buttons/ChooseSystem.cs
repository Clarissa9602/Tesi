using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSystem : MonoBehaviour
{
    public Text systemType;
    private string[] types;
   
    private int i;
    void Start(){

        
        i = 0;
        types = new string[3];

        types[0] = "Sistema Scheletrico";
        types[1] = "Sistema Muscolare";
        types[2] = "Sistema Nervoso";

        
        
        systemType.text = types[0];
    }
    public void changeUp(){
        if(i == 0)
            i = 2;
        else if(i > 0)
            i--;
        systemType.text = types[i];
    }
    public void changeDown(){
        if(i == 2)
            i = 0;
        else if(i < 3)
            i++;
        systemType.text = types[i];
    }
}
