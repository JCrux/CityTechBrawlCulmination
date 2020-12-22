using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_PS_V2 : MonoBehaviour
{
   // public GameObject Punch2Obj;
    public Rigidbody2D rb;
    public Animator anim;
    public float jump = 1;
    public Transform target;
    public int punchTimer = 0;
    //private bool doubleTap;
    // public float doubleTapTime = 0f;
    private enum State { idle, walking, jumping, falling }
    private State state = State.idle;
    private Collider2D coll;
    private float timestamp;
    private SpriteRenderer spriteRender;
    [SerializeField] private LayerMask Ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        //target = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();

    }
    private void Update()
    {


        float hDirection = Input.GetAxis("Horizontal");

        detectDirection();

        //left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            //transform.localScale = new Vector2(-1, 1);
            anim.SetBool("HP_Bwalk", true);

            /* pseudo code
             if the player is facing opponent in negative(left side) walk back animation

             */
        }
        //right
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            //transform.localScale = new Vector2(1, 1);
            anim.SetBool("HP_Fwalk", true);
        }

        else
        {
            anim.SetBool("HP_Fwalk", false);
            anim.SetBool("HP_Bwalk", false);
            //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);// trying to stop slide
        }

        /*  THIS IS THE ATTACK METHOD 
        if (Input.GetKeyDown(KeyCode.N))
        {
            anim.SetBool("HP_Punch2", true);
            Punch2Obj.SetActive(true);
        }
        else
        {
            anim.SetBool("HP_Punch2", false);
            
        }
        if (Punch2Obj.activeSelf == true) 
        {
            punchTimer += 1;
            
        }
        if (punchTimer >= 85)
        {
            Punch2Obj.SetActive(false);
            punchTimer = 0;
        } */


        /* while (Input.GetKey(KeyCode.A)^ Input.GetKey(KeyCode.D)) {


            if () {

                anim.SetBool("walking back", true);
            }
        
        }  */

        if (Time.time >= timestamp && Input.GetKeyDown(KeyCode.W))//&& coll.IsTouchingLayers(Ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 18f);
            timestamp = Time.time + jump;// allows to jump x per second
            anim.SetBool("HP_Jump", true);
            // state = State.jumping;

        }


      /*  else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("HP_Crouch", true);
            anim.SetBool("HP_Idle", false);
            rb.velocity = new Vector2(0, 0); //makes it so you don't move on x axis while crouching
        }
        else
        {
            anim.SetBool("HP_Crouch", false);
        }
        */

        VelocityState();
        anim.SetInteger("state", (int)state);





    }

    void detectDirection()
    {
        Vector2 r = this.transform.position - target.position;
        if (r.x < 0)
        {

            transform.localScale = new Vector2(5.1f, 5.1f);
        }

        if (r.x > 0)
        {


            transform.localScale = new Vector2(-5.1f,5.1f);
        }

    }

    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
                Debug.Log("falling");
            }
        }

        else if (coll.IsTouchingLayers(Ground))
        {
            if (rb.velocity.y < .1f)
            {
                anim.SetBool("HP_Jump", false);
               state = State.idle;
                // Debug.Log("idle");
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            //moving
            state = State.walking;
        }
        else
        {
            state = State.idle;
        }
    }
}
