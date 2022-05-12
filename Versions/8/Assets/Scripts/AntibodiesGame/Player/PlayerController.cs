using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    public HealtBar healtBar;
    public GameObject GameManagerPlayer;
    // Reference al testo delle vite
    // Vite massime del giocatore
    const int MaxLives = 100;
    // Vite attuali del player
    int lives;
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

    public void Init(){
        // Inizialmente le vite sono al completo
        transform.position = new Vector2(0, -3.4f);
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
        initialPosition = new Vector2(0, -3.4f);
    }

    private void Attack(){
       int i = 0;

       // Manage the series of the bullet
       while(i < howManyBulletInSeries){
            // Istantiate the prefab of bullets
            GameObject bullet01 = (GameObject)Instantiate(PlayerBullet);
            
            // Set the bullet initial position
            bullet01.transform.position = bulletPosition01.transform.position;
           
            i++;
       }
    }
    private void OnMouseDown(){
        // Setta deltaX prendendo le coordinate del mouse nello spazio e sottraendogli la posizione dell'oggetto 
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag(){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX,  mousePosition.y - deltaY);
    }
    private void OnMouseUp(){
        // Riporta l'oggetto alla posizione iniziale
        transform.position = initialPosition;
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
        if(lives == 0){
            Stop();
            GameManagerPlayer.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);   
        }
    }
}
