using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Legs : MonoBehaviour{
    [SerializeField]
    private GameObject objLeg;
    [SerializeField]
    private Transform rightPlaceL;
    [SerializeField]
    private Transform rightPlaceR;

    private Vector3 initialPosition;
    private Vector3 mousePosition;
    private float deltaX, deltaY;
    public static bool locked;

    void Start(){
        initialPosition = transform.position;
        locked = true;
    }
    void OnMouseDown(){
        if(!locked){
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }

    void OnMouseDrag(){
        if(!locked){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x - deltaX,  mousePosition.y - deltaX);
        }
    }
    private void OnMouseUp(){
        if(Mathf.Abs(transform.position.x - rightPlaceL.position.x) <= 50f &&
            Mathf.Abs(transform.position.y - rightPlaceL.position.y) <= 50f){
                transform.position = new Vector3(rightPlaceL.position.x, rightPlaceL.position.y);
                GameObject rightLeg = GameObject.Instantiate(objLeg, new Vector3(   objLeg.transform.position.x+100,
                                                                                    objLeg.transform.position.y,
                                                                                    objLeg.transform.position.z), 
                                                                                    objLeg.transform.rotation);
                locked = true;
                SkeletronScore.Instance.AddPoint();
                disableButton();
        }
        else 
        if(Mathf.Abs(transform.position.x - rightPlaceR.position.x) <= 50f &&
            Mathf.Abs(transform.position.y - rightPlaceR.position.y) <= 50f){
                transform.position = new Vector3(rightPlaceR.position.x, rightPlaceR.position.y);
                GameObject leftArm = GameObject.Instantiate(objLeg, new Vector3(    objLeg.transform.position.x-100,
                                                                                    objLeg.transform.position.y,
                                                                                    objLeg.transform.position.z), 
                                                                                    objLeg.transform.rotation);
                locked = true;
                SkeletronScore.Instance.AddPoint();
                //disableButton();
        }
        else{
            transform.position = new Vector3(initialPosition.x, initialPosition.y);
        }
    }
    public void disableButton(){
        GameObject.Find("btnBraccia").GetComponent<Image>().color = new Color(120f, 37f, 0f, 255f);
        GameObject.Find("btnBraccia").GetComponentInParent<Button>().enabled = false;        
    }
    public void Unlock(){
        locked = false;
    }
    public void Lock(){
        locked = true;
    }
}
