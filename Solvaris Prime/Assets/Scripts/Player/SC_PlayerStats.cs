using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth;

    [Header("Movement")]
    public float moveSpeed;

    [Header("Shooting")]
    public float bulletDamage;
    public float bulletSpeed;
    public float bulletLife;
    public int bulletAmount;
    public float shootCooldown;
}
