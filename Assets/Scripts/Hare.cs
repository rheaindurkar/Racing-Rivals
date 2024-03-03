using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hare : MonoBehaviour
{
    public float jumpForce = 20.0f;
    public float speed = 7.0f;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    public float fallMultiplier;
    Vector2 gravitycheck;
    Vector2 startPosition;
    private float decreaseTimer;
    private bool decreasing;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        gravitycheck = new Vector2(0, -Physics2D.gravity.y);
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
    
        decreaseTimer = 0;
        decreasing = false;

    }

    // Update is called once per frame
    void Update()
    {
       

        if(decreasing){
            decreaseTimer += Time.deltaTime;
            if (decreaseTimer >=5){
                speed = 7.0f;
                decreaseTimer = 0;
                decreasing = false;
            }
        }

        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f,0.314619f), CapsuleDirection2D.Horizontal, 0, groundLayer);

          
        if ( Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.velocity =  Vector2.up * jumpForce;
        }

        if(rb.velocity.y<0){
            rb.velocity -= gravitycheck*fallMultiplier*Time.deltaTime;
        }
    }

    void FixedUpdate(){
         if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector2.left * Time.deltaTime * speed);

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collison){
        if (collison.CompareTag("Obstacle")){
            Die();
        }
        if (collison.CompareTag("speedSlow")){
            decreasing = true;
            speed = 1.0f;
        }
    }

    
     void Die(){
        Respawn();
     }
     void Respawn(){
        transform.position = startPosition;
     }
}
