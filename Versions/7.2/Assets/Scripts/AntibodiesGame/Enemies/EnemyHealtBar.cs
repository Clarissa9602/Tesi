using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealtBar: MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    private void Update(){
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position);
    }
    public void setMaxHealt(int healt){
        slider.maxValue = healt;
        slider.value = healt;

        fill.color = gradient.Evaluate(1f);
    }
    public void setHealt(int healt){
        slider.value = healt;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
