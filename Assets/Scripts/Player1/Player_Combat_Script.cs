using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat_Script : MonoBehaviour
    
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
    public bool Blocking = false;

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

    Block();
        { }
        
}
    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.I) && PressButtonTimer <= 0)
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
            if (Input.GetKeyDown(KeyCode.O) && PressButtonTimer <= 0)
            {
                PressButtonTimer = .8f;
                spawnHitBoxTimer = .2f;
                Debug.Log("pressed kick1");
                spawnHitBox = kickbox;
                spawnPoint = kickPoint;
                
                anim.SetTrigger("kick1");
                Debug.Log("kick1");
               

               
            }

       
    }
    public void Block()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Block");
            Blocking = true;
        }
    }

    void spawnTheHitBox()
    {   if(spawnHitBox != null)
        {
         
         spawnHitBox.SetActive(true);
         spawnHitBox = null;    
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player2")
        {
            Debug.Log("Yeeeeeeeeeeeeeet");

        }
    }

}

