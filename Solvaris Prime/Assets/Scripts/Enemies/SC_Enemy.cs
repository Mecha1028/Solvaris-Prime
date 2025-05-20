using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject PB_Player;
    Vector2 PlayerPosition = Vector2.zero;

    public float Health;
    public bool IsMelee;
    public float Damage;
    public float moveSpeed;

    private bool DidMelee;

    public GameObject[] PowerUps;

    void Update()
    {
        PlayerPosition = PB_Player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsMelee)
            {
                DidMelee = true;
                SC_Player Player = PB_Player.GetComponent<SC_Player>();
                Player.TakeDamage(Damage);
                TakeDamage(Health);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void FixedUpdate()
    {
        Vector2 LookDirection = PlayerPosition - rb.position;
        rb.rotation = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
        if (rb.bodyType != RigidbodyType2D.Kinematic)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        if (!DidMelee)
        {
            int number = UnityEngine.Random.Range(0, 100);
            if (number < 100)
            {
                int Position = UnityEngine.Random.Range(0, 3);
                GameObject Powerup = Instantiate(PowerUps[Position]);
                Powerup.transform.position = rb.position;
            }
        }
        Destroy(gameObject);
    }
}