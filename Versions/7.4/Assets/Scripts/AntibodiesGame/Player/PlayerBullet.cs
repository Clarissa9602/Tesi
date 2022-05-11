using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour{
    // Speed of the bullet
    private float speed;
    void Start(){
        speed = 3f;
    }

    // Update is called once per frame
    void Update(){
        // Get current position of the bullet 
        Vector2 position = transform.position;

        // Compute new position 
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        
        // Update bullet position with new
        transform.position = position;

        // Set the max width and height of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        // Destroy the bullet if it go outside the top of screen
        if(transform.position.y > max.y){
            // Destroy or setActive(false)??
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        // If the player is shooted by enemy ship 
        if(col.tag == "EnemyShipTag"){
            //Destroy the bullet if it has shoot the ship
            Destroy(gameObject);
        }
    }
    public void StopShoot(){
        Destroy(this.gameObject);
    }
}
