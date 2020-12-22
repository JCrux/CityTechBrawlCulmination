using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_HPB_PS : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Animator anim;
    public float jump = 1;
    public Transform target;
    public int punchTimer = 0;
   
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
       

    }
    private void Update()
    {


        float hDirection = Input.GetAxis("Horizontal");

        detectDirection();

        //left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            //transform.localScale = new Vector2(-1, 1);
            anim.SetBool("EHPB_BWalk", true);

            /* pseudo code
             if the player is facing opponent in negative(left side) walk back animation

             */
        }
        //right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            //transform.localScale = new Vector2(1, 1);
            anim.SetBool("EHPB_FWalk", true);
        }

        else
        {
            anim.SetBool("EHPB_FWalk", false);
            anim.SetBool("EHPB_BWalk", false);
            
        }


        if (Time.time >= timestamp && Input.GetKeyDown(KeyCode.UpArrow))//&& coll.IsTouchingLayers(Ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 18f);
            timestamp = Time.time + jump;// allows to jump x per second
            anim.SetBool("EHPB_Jump", true);
            // state = State.jumping;

        }
      
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


            transform.localScale = new Vector2(-5.1f, 5.1f);
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
                anim.SetBool("EHPB_Jump", false);
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
