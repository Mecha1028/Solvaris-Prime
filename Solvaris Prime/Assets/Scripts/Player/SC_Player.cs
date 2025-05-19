using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Player : MonoBehaviour
{
    public GameObject PB_Player;
    public GameObject PB_HealthBar;

    public float maxHealth;
    public float currentHealth;

    private void Start()
    {
        SC_PlayerStats PlayerStats = PB_Player.GetComponent<SC_PlayerStats>();
        maxHealth = PlayerStats.maxHealth;
        currentHealth = maxHealth;
        SC_HealthBar HealthBar = PB_HealthBar.GetComponent<SC_HealthBar>();
        HealthBar.InitHealthBar(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        SC_HealthBar HealthBar = PB_HealthBar.GetComponent<SC_HealthBar>();
        HealthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Kill Player Not Implemented");
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TakeDamage(0.5f);
        }
    }
}
