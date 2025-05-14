using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_TestDummy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject PB_Player;

    public float moveSpeed = 2f;

    Vector2 PlayerPosition = Vector2.zero;

    public float Health = 10f;

    void Update()
    {
        PlayerPosition = PB_Player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
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
}
