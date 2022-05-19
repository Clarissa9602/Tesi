using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NG_PlayerController : MonoBehaviour{
    private Rigidbody r;
    private Vector3 defaultScale;
    private bool grounded = false;
    
    private int life;
    public GameObject[] hearts;
   
    public float gravity = 20.0f;
    public float jumpHeight = 2.5f;
    public float moveSpeed = 3;


    void Start(){
        SetInfo();
    }

    void Update(){      
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded){
            r.velocity = new Vector3(r.velocity.x, CalculateJumpVerticalSpeed(), r.velocity.z);
        }
        else{
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 7);
        }

        // Move left
        if (Input.GetKey(KeyCode.A) && grounded){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            r.transform.position -= Camera.main.transform.right * 0.04f * 3;
        }
        // Move Right
        if (Input.GetKey(KeyCode.D) && grounded){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            r.transform.position += Camera.main.transform.right * 0.04f * 3;
        }
        
        else{
            // Start Run
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        // We apply gravity manually for more tuning control
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        grounded = false;
    }

    void OnCollisionStay(){
        grounded = true;
    }

    float CalculateJumpVerticalSpeed(){
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Finish"){
            //Stop player movement at current coordinates
            StartCoroutine("StopMovement");
            TakeDamage(1);
        }
    }
    void OnTriggerEnter(Collider coll){
        Debug.Log(coll.gameObject.name);
        if(coll.gameObject.layer == 9){
            FindObjectOfType<NG_GameManager>().GameOver();
        }
    }

    IEnumerator StopMovement(){
        moveSpeed = 0;
        yield return new WaitForSeconds(1f);
        moveSpeed = 5;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        StopCoroutine("StopMovement");
    }
    private void TakeDamage(int d){
        life -= d;
        hearts[life].gameObject.SetActive(false);

        if(life < 1){
            FindObjectOfType<NG_GameManager>().GameOver();
        }
    }

    public void SetInfo(){
        moveSpeed = 5; 
        life = hearts.Length;
        foreach(GameObject h in hearts)
            h.SetActive(true);
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionZ;  
        r.freezeRotation = true;
        r.useGravity = false;
        defaultScale = transform.localScale;
    }
}
