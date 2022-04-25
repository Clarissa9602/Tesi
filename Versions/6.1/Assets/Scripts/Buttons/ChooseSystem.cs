using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSystem : MonoBehaviour
{
    private static ChooseSystem instance;
    public Text systemType;
    private string[] types;
   
    private int i;
    void Start(){
        i = 0;
        instance = this;
        types = new string[4];

        types[0] = "Sistema Scheletrico";
        types[1] = "Sistema Muscolare";
        types[2] = "Sistema Nervoso";
        types[3] = "Sistema Linfatico";

        
        instance.systemType.text = types[0];
    }
    public void changeUp(){
        if(i == 0)
            i = 3;
        else if(i > 0)
            i--;
        instance.systemType.text = types[i];
    }
    public void changeDown(){
        if(i == 3)
            i = 0;
        else if(i < 4)
            i++;
        instance.systemType.text = types[i];
    }

    public static ChooseSystem Instance{
        get
        {
            return instance;
        }
    }
}
