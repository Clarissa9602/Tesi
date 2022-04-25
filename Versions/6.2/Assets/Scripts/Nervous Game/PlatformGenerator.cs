using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public ObjectPooler objectPool;
    
    public Transform generationPoint;
    public float randomMessage;
    private float platformWidth;
    
    private MessageGenerator mGenerator;
    private ObstaclesGenerator oGenerator;
   

    private void Start(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        platformWidth = 10;
        generationPoint = GameObject.Find("PlatformGenerationPoint").transform;
    
        mGenerator = FindObjectOfType<MessageGenerator>();


        oGenerator = FindObjectOfType<ObstaclesGenerator>();
    }

    void Update(){
        if(transform.position.z < generationPoint.position.z){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth);

            // This instantiate a new pool of platforms
            GameObject newPlatform = objectPool.GetPooledObject();
            
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            // Spawn the messages in a specific position
            if(Random.Range(0f,100f) < randomMessage){ 
                mGenerator.SpawnMessages(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }
            // Spawn the obstacles
            oGenerator.SpawnObstacles(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        
        }   

    }
}
