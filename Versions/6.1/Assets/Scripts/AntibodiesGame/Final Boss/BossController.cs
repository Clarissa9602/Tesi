using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour{

    public HealtBar healtBar;
    public GameObject BossBullet;

    public GameObject bulletPosition01;
    public GameObject bulletPosition02;

    private Vector2 initialPosition;
    private Vector2 mousePosition;
   
    private float deltaX, deltaY;
    // Reference al testo delle vite
    // Vite massime del giocatore
    private const int MaxLives = 1300;
    // Vite attuali del player
    private int lives;
    // Time between the series of the bullet
    public float timeBetweenSeries = 2f;
    
    // Time between aech bullet

    public float timeBetweenBullets = 0.2f;

    // How many bullet we need to instantiate
    public int howManyBulletInSeries = 5;

    public void Init(){
        // Inizialmente le vite sono al completo
        //transform.position = new Vector2(0, -5.55f);
        lives = MaxLives;
        healtBar.setMaxHealt(MaxLives);
        gameObject.SetActive(true);
        InvokeRepeating("Attack", 1f, timeBetweenSeries);
        
    }
    public void Stop(){
        gameObject.SetActive(false);
        CancelInvoke("Attack");
    }
    private void Start(){
        // Inizializza la posizione iniziale a quella corrente
        initialPosition = new Vector2(0, -5.55f);
    }

    private void Attack(){
       int i = 0;
       Debug.Log("Attack");

       // Manage the series of the bullet
       while(i < howManyBulletInSeries){
            // Istantiate the prefab of bullets
            GameObject bullet01 = (GameObject)Instantiate(BossBullet);
            //GameObject bullet02 = (GameObject)Instantiate(BossBullet);
            
            // Set the bullet initial position
            bullet01.transform.position = bulletPosition01.transform.position;
            //bullet02.transform.position = bulletPosition02.transform.position;
           
            i++;
       }
    }
    private void Attack1(){
       int i = 0;

       // Manage the series of the bullet
       while(i < howManyBulletInSeries){
            // Istantiate the prefab of bullets
            GameObject bullet01 = (GameObject)Instantiate(BossBullet);
            
            // Set the bullet initial position
            bullet01.transform.position = bulletPosition01.transform.position;
           
            i++;
       }
    }
    private void Attack2(){
       int i = 0;

       // Manage the series of the bullet
       while(i < howManyBulletInSeries){
            // Istantiate the prefab of bullets
            GameObject bullet01 = (GameObject)Instantiate(BossBullet);
            
            // Set the bullet initial position
            bullet01.transform.position = bulletPosition01.transform.position;
           
            i++;
       }
    }
    void OnTriggerEnter2D(Collider2D col){
        // Detect the collsion of the ship with enemy ship or bullet
        if((col.tag == "EnemyShipTag") || col.tag == "EnemyBulletTag"){
            TakeDamage(10);
        }
    }

    private void TakeDamage(int demage){
        // Se colpito perde una vita
        lives -= demage;
        healtBar.setHealt(lives);
        if(lives <= 900){
            Debug.Log("Attacco 1");
            // Se l'energia del nemico scende sotto questa soglia incrementa il suo attacco
            //Attack1();
        }
        else if(lives <= 500){
            Debug.Log("Attacco 2");
            //Attack2();
        }
        else if(lives == 0){
            Debug.Log("Sconfitto Boss");
            Destroy(this.gameObject);
        }
    }
}
