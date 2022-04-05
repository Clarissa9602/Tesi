using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{

    public GameObject scoreText;
    // Speed of the movement
    private float speed;
    
    void Start(){
        speed = 2f;
        scoreText = GameObject.FindGameObjectWithTag("ScoreTextTag");
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
    }
    void OnTriggerEnter2D(Collider2D col){
        
        // If the enemy ship is shooted by player bullet
        if(col.tag == ("PlayerBulletTag")){
            switch(this.gameObject.name){
                case "Virus(Clone)":
                    scoreText.GetComponent<AntibodiesScore>().Score += 100;
                break;
                case "Mycosis(Clone)":
                    scoreText.GetComponent<AntibodiesScore>().Score += 15;
                break;
                case "Bacterium(Clone)":
                    scoreText.GetComponent<AntibodiesScore>().Score += 50;
                break;

            }
            //Destroy enemy ship
            Destroy(gameObject);
        }
    }
}
