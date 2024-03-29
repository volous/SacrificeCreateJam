using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector3 moveInput;
    public float moveSpeed = 5f; // Speed of the player movement

    private Rigidbody2D rb;
    private Vector2 moveDirection; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
    }
    void OnMove(InputValue iv)
    {
        // Read the input value from the Input System
        Vector2 inputVector = iv.Get<Vector2>();

        // Normalize the input vector to ensure constant movement speed diagonally
        moveDirection = inputVector.normalized;
    }
    void FixedUpdate()
    {
        Move();

    }
    void Move()
    {
        // Move the player based on the moveDirection and moveSpeed
        rb.velocity = moveDirection * moveSpeed;
    }
}
