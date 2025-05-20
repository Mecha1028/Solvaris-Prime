using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MoveSpeedPowerup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SC_PlayerStats PlayerStats = collision.GetComponent<SC_PlayerStats>();
            PlayerStats.moveSpeed += 2;
            Destroy(gameObject);
        }
    }
}
