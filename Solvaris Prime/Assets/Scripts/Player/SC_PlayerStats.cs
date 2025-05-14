using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 10f;
    public float maxShield = 0f;

    [Header("Shooting")]
    public float bulletDamage = 5f;
    public float bulletSpeed = 3f;
    public float bulletLife = 3f;

    [Header("Abilities")]
    public float PrimaryAbilityCooldown;
    public float SecondaryAbilityCooldown;
}
