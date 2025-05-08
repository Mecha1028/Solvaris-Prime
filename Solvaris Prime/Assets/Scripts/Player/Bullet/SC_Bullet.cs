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

    IEnumerator DestoryBullet()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}



