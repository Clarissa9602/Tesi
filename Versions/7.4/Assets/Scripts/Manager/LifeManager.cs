using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour{
    private int life;
    public GameObject[] hearts;
    // Start is called before the first frame update
    public void Start(){
        life = hearts.Length;
        foreach(GameObject h in hearts)
            h.SetActive(true);
    }

    // Needs to find another name for this method
    public void TakeDamage(int d){
        life -= d;
        hearts[life].gameObject.SetActive(false);

        if(life < 1){
            FindObjectOfType<MG_GameManager>().GameOver();
            life = hearts.Length;
        }
    }
}
