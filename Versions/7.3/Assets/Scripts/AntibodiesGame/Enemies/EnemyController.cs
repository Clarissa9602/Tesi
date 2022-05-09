using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    
    public GameObject scoreText;
    public HealtBar enemyHealtBar;
    public int MaxLives;

    private float speed;
    private int lives;
    private float offsetX, offsetY;
    
    void Start(){
        speed = 2f;
        scoreText = GameObject.FindGameObjectWithTag("ScoreTextTag");
        lives = MaxLives;
        offsetX = this.gameObject.transform.position.x;
        offsetY = 0.8f;
    }

    void Update(){
        Vector2 position = transform.position;
       
        // Compute the movement of the enemy
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        // Set the min position of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        // If the enemy go above the screen it will be destroy
        if(transform.position.y < min.y){
            Destroy(gameObject);
        }
        enemyHealtBar.transform.position = new Vector2(offsetX,this.gameObject.transform.position.y+offsetY);
    }
    void OnTriggerEnter2D(Collider2D col){
        // If the enemy ship is shooted by player bullet
        if(col.tag == ("PlayerBulletTag")){
            switch(this.gameObject.name){
                case "Virus(Clone)":
                    TakeDamage(70);
                    // Score += 100
                break;
                case "Mycosis(Clone)":
                    TakeDamage(10);
                    // score += 15
                break;
                case "Bacterium(Clone)":
                    // Score += 50
                    TakeDamage(30);
                break;
            }
        }
    }
    private void TakeDamage(int demage){
        // Se colpito perde una vita
        lives -= demage;
        enemyHealtBar.setHealt(lives);
        if(lives <= 0){
            if(this.gameObject.name.Equals("Virus(Clone)")){
                // Score += 100
                scoreText.GetComponent<ScoreManager>().Score += 100;
            }
            else if(this.gameObject.name.Equals("Mycosis(Clone)")){
                // score += 15
                scoreText.GetComponent<ScoreManager>().Score += 15;
            }
            else if(this.gameObject.name.Equals("Bacterium(Clone)")){
                // Score += 50
                scoreText.GetComponent<ScoreManager>().Score += 50;
            }      
            Destroy(this.gameObject);
        }
    }
}
