using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ExtraBulletPowerup : MonoBehaviour
{
    public GameObject PB_Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SC_PlayerStats PlayerStats = PB_Player.GetComponent<SC_PlayerStats>();
            PlayerStats.bulletAmount += 2;
            Destroy(gameObject);
        }
    }
}
