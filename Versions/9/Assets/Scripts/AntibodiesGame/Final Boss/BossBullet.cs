using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour{
    private float speed;
    private Vector2 _direction;
    private bool isReady;

    void Awake(){
        // Set the speed of the bullets
        speed = 2f;
        isReady = false;
    }

    public void SetDirection(Vector2 direction){
        _direction = direction.normalized;
        isReady = true;
    }

    void Update(){
        // If the direction is set we can update the bullet position on the screen
        if(isReady){
            Vector2 position = transform.position;

            // Compute the new position every frame ancd change it
            position += _direction * speed * Time.deltaTime;

            //Update bullet's position
            transform.position = position;

            // Bottom-left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
            // Top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

            // If the bullet go above the screen, destroy it
            if( (transform.position.x < min.x) || (transform.position.x > max.x) ||
                (transform.position.y < min.y) || (transform.position.y > max.y)){
                    Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        // If the enemy bullet has shooted player ship
        if(col.tag == "PlayerBulletTag" || col.tag == "PlayerShipTag"){
            //Destroy enemy bullet
            Destroy(gameObject);
        }
    }
}
