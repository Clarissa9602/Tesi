using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour{
    public GameObject playerShip;
    public GameObject UIWaves;
    public List<GameObject> enemiesShip;
    public float[] timerWave;
    private float[] time;
    public int numberWave;
    
    private int i;

    public void playAgain(){
        i = 0;
        StartCoroutine(StartWave());
    }
    private void StartPlayer(){
        playerShip.GetComponent<PlayerController>().Init();
    }
    public void StopPlayer(){
        playerShip.GetComponent<PlayerController>().Stop();
    }
    private void StartEnemies(int nWave){
        enemiesShip[nWave].SetActive(true);   
        enemiesShip[nWave].GetComponent<EnemySpawner>().ScheduleEnemySpawn();
        
    }
    private void StartBoss(int nWave){
        enemiesShip[nWave].SetActive(true);
        enemiesShip[nWave].GetComponent<BossSpawner>();
    }
    public void StopEnemies(int nWave){
        enemiesShip[nWave].SetActive(false);
        if(nWave < numberWave-1){
            enemiesShip[nWave].GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
        }
        else{
            enemiesShip[nWave].GetComponent<BossSpawner>().KilledBoss();
        }
       
    }
    public int getNWaves(){
        return i;
    }
    private void setTime(){
        time = new float[numberWave];
        for(int i = 0; i < numberWave; i++){
            time[i] = timerWave[i];
        }        
    }
    public IEnumerator StartWave(){
        setTime();
        while(i < numberWave-1){
            StartPlayer();
            StartEnemies(i);
            
            while((int)time[i] > 0){
                time[i] -= Time.deltaTime;
                yield return null;
            }
            StopPlayer();
            StopEnemies(i);
            i++;
            UIWaves.GetComponentInChildren<Text>().text = "Fine ondata " + i;
            UIWaves.SetActive(true);
            yield return new WaitForSecondsRealtime(10);
            UIWaves.SetActive(false);
        }
        StartPlayer();
        StartBoss(i);
    }    
}
