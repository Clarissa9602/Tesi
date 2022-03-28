using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour{
    // SPeed of the bullet
    private float speed;
    void Start(){
        speed = 0.01f;
    }

    // Update is called once per frame
    void Update(){
        // Get current position of the bullet 
        Vector2 position = transform.position;

        // Compute new position 
        position = new Vector2(position.x, position.y + speed + Time.deltaTime);
        
        // Update bullet position with new
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        // Destroy the bullet if it go outside the top of screen
        if(transform.position.y > max.y){
            // Destroy or setActive(false)??
            Destroy(gameObject);
        }
    }
}
