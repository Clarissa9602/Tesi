using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    private Vector2 initialPosition;
    private Vector2 mousePosition;
    public GameObject PlayerBullet;
    public GameObject bulletPosition01;
    private float deltaX, deltaY;

    // Time between the series of the bullet
    public float timeBetweenSeries = 2f;
    
    // Time between aech bullet

    public float timeBetweenBullets = 0.2f;

    // How many bullet we need to instantiate
    public int howManyBulletInSeries = 5;

    private void Start(){
        initialPosition = transform.position;
        InvokeRepeating("Shoot", 0f, timeBetweenSeries);
    }
    void Shoot(){
        StartCoroutine(Attack());
    }

    private IEnumerator Attack(){
       int i = 0;

       // Manage the series of the bullet
       while(i < howManyBulletInSeries){
            // Istantiate the prefab of bullets
            GameObject bullet01 = (GameObject)Instantiate(PlayerBullet);
            
            // Set the bullet initial position
            bullet01.transform.position = bulletPosition01.transform.position;
            yield return new WaitForSecondsRealtime(timeBetweenBullets);
            i++;
       }
        
        yield return new WaitForSecondsRealtime(timeBetweenBullets);
        
    }
    private void OnMouseDown(){
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag(){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX,  mousePosition.y - deltaX);
    }
    private void OnMouseUp(){
        transform.position = new Vector2(initialPosition.x, initialPosition.y);
    }
}
