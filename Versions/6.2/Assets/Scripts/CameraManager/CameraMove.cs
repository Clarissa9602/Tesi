using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class allows the camera to follow the path
public class CameraMove : MonoBehaviour{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1);
    }

}
