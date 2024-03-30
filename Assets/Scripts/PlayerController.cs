using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector3 moveInput;
    public float moveSpeed = 5f; // Speed of the player movement
    public bool hasPowerup;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    [SerializeField] private int health = 5;
    [SerializeField] private float speedScaler = 1;
    [SerializeField] private bool immobilized;
    

    private GameManager gm;
    
    
    
    private BasePowerUp currentPowerUp;

    private void Awake()
    {
        FindObjectOfType<PlayerManager>().AddPlayer(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component attached to the player
        currentPowerUp = gameObject.AddComponent<Boost>();
        gm = FindObjectOfType<GameManager>();
    }
    void OnMove(InputValue iv)
    {
        Vector2 inputVector = iv.Get<Vector2>();
        moveDirection = inputVector.normalized;
    }
    void FixedUpdate()
    {
       
        Move();
        ConstraintCheck();
    }

    private void ConstraintCheck()
    {
        if (transform.position.y > 4)
        {
            Vector3 pos = transform.position;
            pos.y = 4;
            transform.position = pos;
        }
        if (transform.position.y < -4)
        {
            Vector3 pos = transform.position;
            pos.y = -4;
            transform.position = pos;
        }
    }

    void Move()
    {
        rb.velocity =immobilized ? Vector3.zero: moveDirection * moveSpeed;
    }

    void OnFire()
    {
        if (currentPowerUp!= null)
        {
            currentPowerUp.Activate();
            currentPowerUp = null;
        }
    }

    public void Heal(int healing)
    {
        health+= healing;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health < 0) 
        {
            gm.EndGame();
        }
    }

    public void SpeedChange(float speed, float time)
    {
        speedScaler = speed;
        Invoke("ResetSpeed",time);
        
    }

    public void ResetSpeed()
    {
        speedScaler = 1;
    }

    public void Mobilize()
    {
        immobilized = false;
    }

    public void Immobilize()
    {
        immobilized = true;
    }
}
