using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickObject : MonoBehaviour{
    private static PickObject _instance;
    public GameObject message;
    private int countMessages;

    private void Start(){
        _instance = this;
        countMessages = 0;
    }
    private void OnTriggerEnter(Collider coll){
        if(coll.tag.Equals("PickMessage")){
            PickedObject();
            coll.gameObject.SetActive(false);
            countMessages++;
        }
    }

    public void PickedObject(){
        StartCoroutine(confirmObject());
    }

    IEnumerator confirmObject(){
        message.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        message.SetActive(false);
        StopCoroutine(confirmObject());
    }

    public static PickObject instance
    {
        get
        {
            return _instance;
        }
    }

    public int getPickedMessages(){
        return countMessages;
    }
}