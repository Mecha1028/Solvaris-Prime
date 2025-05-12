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
        StartCoroutine(DestoryBullet(bulletLife));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DestoryBullet());
    }


    IEnumerator DestoryBullet(float bulletLife = 0)
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}
