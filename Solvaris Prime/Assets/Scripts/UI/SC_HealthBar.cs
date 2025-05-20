using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;
    

    public void InitHealthBar(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        healthText.text = maxHealth.ToString();
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
        healthText.text = health.ToString();
    }
}
