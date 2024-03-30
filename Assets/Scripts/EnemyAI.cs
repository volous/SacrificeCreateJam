using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{

    [SerializeField]private Vector2 moveDirection;
    [SerializeField] private float moveSpeed;
    
    private Rigidbody2D rb;
    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
    }
    void FixedUpdate()
    {
        
            // Move the player based on the moveDirection and moveSpeed
            rb.velocity = moveDirection * moveSpeed;
           
    }
}
