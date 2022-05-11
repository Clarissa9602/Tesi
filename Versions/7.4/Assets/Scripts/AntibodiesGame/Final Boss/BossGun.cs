using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    // Istance of the enemies's bullets
    public GameObject BossBullet;
    void Start(){
        // Invoke after 1 second
        InvokeRepeating("FireBossBullet", 1f, 1);
        
    }


    // Fire enemy bullet
    void FireBossBullet(){
        // Targer of the enemies
        GameObject playerShip = GameObject.Find("Captain Megad");
        
        if(playerShip != null){ // If the player is still playing
            //Instantiate enemy bullets
            GameObject bullet = (GameObject)Instantiate(BossBullet);
            bullet.transform.position = transform.position;

            //Compute the direction of the bullet and assign to it
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Redirect the bullet to the target
            bullet.GetComponent<BossBullet>().SetDirection(direction);
        }
    }
}
