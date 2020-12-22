using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider slider; // health bar code

    public void SetMaxHealth(int health) // hp bar codes
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
    // Start is called before the first frame update
    
}
