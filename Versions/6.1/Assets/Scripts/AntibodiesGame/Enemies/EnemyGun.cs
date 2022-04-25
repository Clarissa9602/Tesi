using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // Istance of the enemies's bullets
    public GameObject EnemyBullet;
    void Start(){
        // Invoke after 1 second
        Invoke("FireEnemyBullet", 1f);
    }

    // Fire enemy bullet
    void FireEnemyBullet(){
        // Targer of the enemies
        GameObject playerShip = GameObject.Find("Captain Megad");
        
        if(playerShip != null){ // If the player is still playing
            //Instantiate enemy bullets
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);
            bullet.transform.position = transform.position;

            //Compute the direction of the bullet and assign to it
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Redirect the bullet to the target
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
