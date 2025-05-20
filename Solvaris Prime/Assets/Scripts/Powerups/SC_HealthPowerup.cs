using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HealthPowerup : MonoBehaviour
{
    public GameObject PB_Player;

    private float HealingDone = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SC_Player Player = PB_Player.GetComponent<SC_Player>();
            if (Player.currentHealth + HealingDone < Player.maxHealth)
            {
                Player.currentHealth += HealingDone;
            }
            else
            {
                Player.currentHealth += Player.maxHealth - Player.currentHealth;
            }
            Player.UpdateHealth(Player.currentHealth);
            Destroy(gameObject);
        }
    }
}
