using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_Bullet : MonoBehaviour
{
    public GameObject PB_Player;
    private void Start()
    {
        //PB_Player = GetComponent<SC_PlayerStats>();
        StartCoroutine(DestoryBullet(3));
    }

    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * 3;
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
