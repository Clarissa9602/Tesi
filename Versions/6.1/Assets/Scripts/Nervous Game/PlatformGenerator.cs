using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    
    public Transform generationPoint;
    private float platformWidth;
    private MessageGenerator mGenerator;

    private void Start(){
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.localPosition.z);
        platformWidth = platform.GetComponentInChildren<BoxCollider>().size.z;
        generationPoint = GameObject.Find("PlatformGenerationPoint").transform;
    
        mGenerator = FindObjectOfType<MessageGenerator>();
    }

    void Update(){
        if(transform.position.z < generationPoint.position.z){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth);
            Instantiate(platform, transform.position, transform.rotation);


            // Spawn the messages in a specific position
            //mGenerator.SpawnMessage(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f));
        }   

    }
}
