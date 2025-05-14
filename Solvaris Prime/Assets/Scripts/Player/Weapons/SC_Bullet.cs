using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_Bullet : MonoBehaviour
{
    public float bulletDamage;
    private void Start()
    {
        StartCoroutine(DestoryBullet(3));
    }


    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SC_Enemy enemy = collision.gameObject.GetComponent<SC_Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
        }
        StartCoroutine(DestoryBullet());
    }


    IEnumerator DestoryBullet(float bulletLife = 0)
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}
