using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2_Combat_Script : MonoBehaviour

{
    public Collider2D hitbox;
    public Collider2D hitboxK;

    public Animator anim;
    float PressButtonTimer = 0f;
    float spawnHitBoxTimer = 0f;

    private GameObject spawnHitBox;
    [SerializeField]

    private GameObject punchbox;
    public GameObject kickbox;

    private GameObject spawnPoint;


    public bool auto1 = false;

    [SerializeField]
    private GameObject punchPoint;
    private GameObject kickPoint;

    // Start is called before the first frame update

    void Start()
    {
        spawnPoint = null;
        spawnHitBox = null;


    }

    // Update is called once per frame
    void Update()
    {
        if (PressButtonTimer >= 0)
        {
            PressButtonTimer -= Time.deltaTime;
            spawnHitBoxTimer -= Time.deltaTime;
        }




        if (spawnHitBoxTimer <= 0)
        {
            spawnTheHitBox();
        }

        Kick();
        { }


        Punch();
        { }


    }
    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.N) && PressButtonTimer <= 0)
        {
            PressButtonTimer = .8f;
            spawnHitBoxTimer = .2f;
            Debug.Log("pressed punch 1");
            spawnHitBox = punchbox;
            spawnPoint = punchPoint;

            anim.SetTrigger("punch1");
            Debug.Log("punch1");



        }

    }

    void Kick()
    {
        if (Input.GetKeyDown(KeyCode.M) && PressButtonTimer <= 0)
        {
            PressButtonTimer = .8f;
            spawnHitBoxTimer = .2f;
            Debug.Log("pressed kick2");
            spawnHitBox = kickbox;
            spawnPoint = kickPoint;

            anim.SetTrigger("kick2");
            Debug.Log("kick2");



        }

    }

    void spawnTheHitBox()
    {
        if (spawnHitBox != null)
        {

            spawnHitBox.SetActive(true);
            spawnHitBox = null;
        }
    }



}

