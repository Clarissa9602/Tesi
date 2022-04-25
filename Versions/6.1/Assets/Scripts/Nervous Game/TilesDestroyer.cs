using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesDestroyer : MonoBehaviour{
    public GameObject platformToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        platformToDestroy = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update(){
        
        if(transform.position.z < platformToDestroy.transform.position.z)
            if(this.gameObject.name.Equals("Tiles(Clone)"))
                Destroy(this.gameObject);
    }
}
