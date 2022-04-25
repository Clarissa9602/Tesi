using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NG_PlayerController : MonoBehaviour{
    public GameObject[] hearts;
    private int life;
    public float gravity = 20.0f;
    public float jumpHeight = 2.5f;
    public float moveSpeed = 3;

    Rigidbody r;
    bool grounded = false;
    Vector3 defaultScale;
    bool crouch = false;

    // Start is called before the first frame update
    void Start(){
        life = hearts.Length;
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        r.useGravity = false;
        defaultScale = transform.localScale;
    }

    void Update(){
        
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded){
            r.velocity = new Vector3(r.velocity.x, CalculateJumpVerticalSpeed(), r.velocity.z);
        }

        //Crouch
        crouch = Input.GetKey(KeyCode.LeftControl);

        if (crouch){
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(defaultScale.x, defaultScale.y * 0.4f, defaultScale.z), Time.deltaTime * 7);
        }
        else{
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, Time.deltaTime * 7);
        }

        // Move left
        if (transform.position.x >= -2 &&
            (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.LeftArrow)) && grounded){
            transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
        }
        // Move right
        if (transform.position.x <= 2 &&
            (Input.GetKeyDown(KeyCode.D)) || (Input.GetKeyDown(KeyCode.RightArrow)) && grounded){
            transform.position = new Vector3(transform.position.x+2, transform.position.y, transform.position.z);
        }
        
        else{
            // Start Run
            transform.Translate(Vector3.forward * Time.deltaTime*moveSpeed);
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
            TakeDamage(1);
            
        }
    }

    private void TakeDamage(int d){
        life -= d;
        hearts[life].gameObject.SetActive(false);

        if(life < 1){
            this.gameObject.SetActive(false);
            FindObjectOfType<GroundGenerator>().GetComponent<GroundGenerator>().GameOver();
        }
    }
}
