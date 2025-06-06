using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject PB_Player;

    private float moveSpeed;
    public IA_PlayerControls playerControls;

    Vector2 moveDirection = Vector2.zero;
    Vector2 mousePosition = Vector2.zero;

    private InputAction move;

    private void Awake()
    {
        playerControls = new IA_PlayerControls();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        moveSpeed = PB_Player.GetComponent<SC_PlayerStats>().moveSpeed;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
