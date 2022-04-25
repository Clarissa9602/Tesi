using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour{
    // Objects to create
    public GameObject pooledObject;

    // Number of objects to create
    public int pooledNumber;

    // List that contains objects created
    List<GameObject> pooledObjects;

    private void Start(){
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < pooledNumber; i++){
            GameObject obj = (GameObject)Instantiate(pooledObject);

            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    // Allow to get object inside the pool
    public GameObject GetPooledObject(){
        for(int i = 0; i < pooledObjects.Count; i++){
            // Return objects pooled if they are not active
            if(!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
  
}
