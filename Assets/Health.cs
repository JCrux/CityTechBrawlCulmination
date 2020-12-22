using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    [SerializeField]
    public Slider Player1Slider;
    [SerializeField]
    public Slider Player2Slider;
    public int startingHealth;
    public int currentHealthP1;
    public int currentHealthP2;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1200, 900, true);
        startingHealth = 100;
        currentHealthP1 = 100;
        currentHealthP2 = 100;

    }

    // Update is called once per frame
    void Update()
    {
        //  Player1Slider.value = currentHealthP1;
        //  Debug.Log(Player1Slider.value);
        Player1Slider.value = currentHealthP1;
       // Debug.Log(Player1Slider.value);

        Player2Slider.value = currentHealthP2;
      //  Debug.Log(Player2Slider.value);


    }

  public   void TakeDamage1(int damage)
    {
        currentHealthP1 -= damage;
    }

   public   void TakeDamage2(int damage)
    {
         currentHealthP2 -= damage;
    }
}
