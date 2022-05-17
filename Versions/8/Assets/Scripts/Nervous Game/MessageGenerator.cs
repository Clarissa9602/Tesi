using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageGenerator : MonoBehaviour{
    public ObjectPooler messagePool;

    // Set distance between messages
    public float distanceBetweenMessage;
    public void SpawnMessages(Vector3 startPosition){
        // Spawn message to center side
        GameObject message1 = messagePool.GetPooledObject();
        //message1.transform.position = startPosition;
        message1.transform.position = new Vector3(startPosition.x - Random.Range(-5f,+5f), startPosition.y, startPosition.z);
        message1.SetActive(true);
    }

}
