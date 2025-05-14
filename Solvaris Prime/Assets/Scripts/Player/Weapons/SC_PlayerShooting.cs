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
    public float shootCooldown = 0.5f;

    public IA_PlayerControls playerControls;
    private InputAction fire;

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
        GameObject bullet = Instantiate(PB_Bullet, ShootPoint.position, ShootPoint.rotation);
        SC_Bullet bulletScript = bullet.GetComponent<SC_Bullet>();
        bullet.transform.localScale = new Vector3(3, 3, 3);
        bulletScript.bulletDamage = PB_Player.GetComponent<SC_PlayerStats>().bulletDamage;
        
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
