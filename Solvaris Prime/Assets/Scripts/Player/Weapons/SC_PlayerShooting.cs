using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_PlayerShooting : MonoBehaviour
{
    public Transform ShootPoint;
    public GameObject PB_Bullet;
    public GameObject PB_Player;

    private bool canShoot = true;
    private float shootCooldown;
    private int bulletAmount;
    private float shootCone;

    public IA_PlayerControls playerControls;
    private InputAction fire;


    private void Start()
    {
        SC_PlayerStats PlayerStats = PB_Player.GetComponent<SC_PlayerStats>();
        shootCooldown = PlayerStats.shootCooldown;
        bulletAmount = PlayerStats.bulletAmount;
        shootCone = bulletAmount * 15;
    }

    private void Awake()
    {
        playerControls = new IA_PlayerControls();
    }
    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
    }

    void Update()
    {
        if (fire.IsPressed() && fire.ReadValue<float>() > 0 && canShoot)
        {
            canShoot = false;
            Shoot();
            StartCoroutine(ShootCooldown());
        }
    }

    void Shoot()
    {
        float startAngle = -shootCone / 2;
        int intervals = bulletAmount - 1;
        float angleSpacing = shootCone / intervals;
        if (bulletAmount > 1)
        {
            for (int i = 0; i < bulletAmount; i++)
            {
                float angle = startAngle + i * angleSpacing;
                Quaternion offsetRotation = Quaternion.Euler(0f, 0f, angle);
                Quaternion finalRotation = ShootPoint.rotation * offsetRotation;

                GameObject bullet = Instantiate(PB_Bullet, ShootPoint.position, finalRotation);
                SC_Bullet bulletScript = bullet.GetComponent<SC_Bullet>();
                bullet.transform.localScale = new Vector3(3, 3, 3);
                bulletScript.bulletDamage = PB_Player.GetComponent<SC_PlayerStats>().bulletDamage;
            }
        }
        else
        {
            GameObject bullet = Instantiate(PB_Bullet, ShootPoint.position, ShootPoint.rotation);
            SC_Bullet bulletScript = bullet.GetComponent<SC_Bullet>();
            bullet.transform.localScale = new Vector3(3, 3, 3);
            bulletScript.bulletDamage = PB_Player.GetComponent<SC_PlayerStats>().bulletDamage;
        }
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
