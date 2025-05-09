using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_TestDummy : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject PB_Player;

    Vector2 PlayerPosition = Vector2.zero;

    public float Health = 10f;

    void Update()
    {
        PlayerPosition = PB_Player.transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 LookDirection = PlayerPosition - rb.position;
        rb.rotation = Mathf.Atan2(LookDirection.y, LookDirection.x) * Mathf.Rad2Deg - 90f;
    }
}
