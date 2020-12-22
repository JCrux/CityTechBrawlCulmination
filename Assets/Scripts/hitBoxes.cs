using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxes : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public Health health;

    public float destroyAfter = .8f;

     public bool isPlayer2 = false;

    public bool isPlayer1 = false;
    void Start()
    {
           health = FindObjectOfType<Health>();
           
    }

    // Update is called once per frame
    void Update()
    {
        destroyAfter -= Time.deltaTime;
        if(destroyAfter <= 0)
        {
             destroyAfter = .4f;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
      
        Debug.Log("hit");
        WhichPlayer();
      
    }

    void WhichPlayer()
    {
                if(isPlayer2 == false)
            {
               
                health.TakeDamage2(damage);
                destroyAfter = .4f;
            }

            
        if(isPlayer2 == true)
            {
               
                health.TakeDamage1(damage);
                destroyAfter = .4f;
            }
    }

            
}
