using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Head : MonoBehaviour{
   
    [SerializeField]
    private Transform rightPlace;
    private Vector3 initialPosition;
    private Vector3 mousePosition;
    private float deltaX, deltaY;
    public static bool locked;

    void Start(){
        initialPosition = transform.position;
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
        if(Mathf.Abs(transform.position.x - rightPlace.position.x) <= 50f &&
            Mathf.Abs(transform.position.y - rightPlace.position.y) <= 50f){
                transform.position = new Vector3(rightPlace.position.x, rightPlace.position.y);
                locked = true;
                SkeletronScore.Instance.AddPoint();
                //disableButton();
        }
        else{
            transform.position = new Vector3(initialPosition.x, initialPosition.y);
        }
    }

    public void disableButton(){
        GameObject.Find("btnCranio").GetComponent<Image>().color = new Color(120f, 37f, 0f, 255f);
        GameObject.Find("btnCranio").GetComponentInParent<Button>().enabled = false;        
    }
    public void Unlock(){
        locked = false;
    }
    public void Lock(){
        locked = true;
    }
}