using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHPB_damageTaken : MonoBehaviour
{
    // original code below this comment( self notes for extreme sleep deprivation)
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        // play some hurt animation
        animator.SetTrigger("EHPB_Hurt");

        //check if current health is less than or = 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Oppnent died");
        //Die animation
        animator.SetBool("Death", true);


        // Disable enemy/ P1 or P2
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
