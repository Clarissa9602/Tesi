using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesDestroyer : MonoBehaviour{
    public GameObject platformToDestroy;
    void Start()
    {
        platformToDestroy = GameObject.Find("PlatformDestructionPoint");
    }

    void Update(){
        
        if(transform.position.z < platformToDestroy.transform.position.z)
            //if(this.gameObject.name.Equals("Tiles(Clone)"))
                this.gameObject.SetActive(false);
    }
}
