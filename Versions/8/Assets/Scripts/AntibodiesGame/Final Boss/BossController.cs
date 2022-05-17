using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour{
    
    public GameObject scoreText;
    public HealtBar bossHealtBar;
    private GameManager gManag;
    private BossGun powerUp;
    public int MaxLives;

    private int lives;
    
    private void Start(){
        scoreText = GameObject.FindGameObjectWithTag("ScoreTextTag");
        gManag = FindObjectOfType<GameManager>();
        lives = MaxLives;
    }
    private void OnTriggerEnter2D(Collider2D col){
        // If the enemy ship is shooted by player bullet
        if(col.tag == ("PlayerBulletTag")){
            TakeDamage(10);
        }
    }
    private void TakeDamage(int demage){
        // Se colpito perde una vita
        lives -= demage;
        bossHealtBar.setHealt(lives);

        // Se l'energia del nemico scende tra i 900 e i 500 incrementa il suo attacco
        if(700 < lives && lives <= 900){
            //CancelInvoke("Attack");
            //Attack1();
        }
        else if(300 < lives && lives <= 700){
            //CancelInvoke("Attack1");
            //Attack2();
        }
        else if(lives <= 0){
            //CancelInvoke("Attack2");
            
            gManag.SetGameManagerState(GameManager.GameManagerState.Completed);
            this.gameObject.SetActive(false);
        }
    }
    
}
