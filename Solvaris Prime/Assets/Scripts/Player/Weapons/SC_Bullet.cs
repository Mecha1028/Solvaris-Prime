using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_Bullet : MonoBehaviour
{
    public float bulletLife = 3f;

    private void Start()
    {
        StartCoroutine(DestoryBullet());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    IEnumerator DestoryBullet()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}



