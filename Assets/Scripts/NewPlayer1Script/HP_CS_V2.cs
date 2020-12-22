using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_CS_V2 : MonoBehaviour
{
    public Animator animator;

    public Transform Punch1Obj; // hit box for 1st punch animation
    public Transform Punch2Obj; // hit box for 2nd punch animation
    public Transform KickObj; // hit box for the kick animation

    public LayerMask enemyLayers;

    public float punchRange = 0.5f;
    public float punchRange2 = 0.5f;
    public float kickRange = 0.5f;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    
    public int attackDamage = 10; // atk dmg ammount for punch1
    public int attackDamage2 = 20; // atk dmg ammount for punch2
    public int attackDamage3 = 15; // atk dmg ammount for kick


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.N)) // plays punch  1
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.M)) //plays punch 2
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if(Input.GetKeyDown(KeyCode.B)) // should play kick
            {
                Attack3();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }
    void Attack()
    {
        //Play an Attack animation
        animator.SetTrigger("HP_Punch1");

        //Detect All enemies in range of Attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Punch1Obj.position,punchRange,enemyLayers);

        //Apply damage to those enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<DamageTaken>().takeDamage(attackDamage);
        }

        //punch2
    }

    void Attack2()
    {
        animator.SetTrigger("HP_Punch2");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Punch2Obj.position, punchRange2, enemyLayers);

        //applies punch 2 dmg
        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<DamageTaken>().takeDamage(attackDamage2);
        }
    }

    void Attack3()
    {
        animator.SetTrigger("HP_Kick");

        Collider2D[] hitEnenemies = Physics2D.OverlapCircleAll(KickObj.position, kickRange, enemyLayers);

        foreach(Collider2D enemy in hitEnenemies)
        {
            Debug.Log("We Kicked the" + enemy.name);
            enemy.GetComponent<DamageTaken>().takeDamage(attackDamage3);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (Punch1Obj == null)
            return;
        Gizmos.color = new Color(0, 0, 0,0.0f); // COLOR of Hit box , make sure to duplicate and adjust for other attack objects
        Gizmos.DrawCube(Punch1Obj.position, new Vector3(1,1,1));

        if (Punch2Obj == null)
            return;
        Gizmos.color = new Color(0, 1, 0, 0.5f); // COLOR of Hit box , make sure to duplicate and adjust for other attack objects
        Gizmos.DrawCube(Punch2Obj.position, new Vector3(1, 1, 1));

        if (KickObj == null)
            return;
        Gizmos.color = new Color(0, 0, 1, 0.5f); // COLOR of Hit box , adjust parameters 1 through 3 to see gizmo color
        Gizmos.DrawCube(KickObj.position, new Vector3(1, 1, 1));
    }
}
