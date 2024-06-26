using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector3 moveInput;
    public float moveSpeed = 5f; 
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    [SerializeField] private Vector2 lookDirection;
    
    [SerializeField] private int health = 5;
    [SerializeField] private float speedScaler = 1;
    [SerializeField] private bool immobilized;
    [SerializeField] private bool beingControlled;
    [SerializeField] private Vector2 controlDirection;
    [SerializeField] private float controlSpeedScaler;
    
    
    
    [SerializeField] private Transform pointer;
    private Collider2D component;

    private GameManager gm;
    
    
    
    [SerializeField] private BasePowerUp currentPowerUp;
    [SerializeField] private SpriteRenderer playerSprite;
    

    private void Awake()
    {
        FindObjectOfType<PlayerManager>().AddPlayer(this);
    }

    void Start()
    {
        component = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>(); 
        gm = FindObjectOfType<GameManager>();
    }
    void OnMove(InputValue iv)
    {
        Vector2 inputVector = iv.Get<Vector2>();
        moveDirection = inputVector.normalized;
    }

    void OnLook(InputValue iv)
    {
        Vector2 inputVector = iv.Get<Vector2>();
        if (inputVector != Vector2.zero)
            lookDirection = inputVector.normalized;
    }
    void FixedUpdate()
    {
        if (beingControlled)
        {
            ControlledMove();
        }
        else
        {
            Move();
        }
        ConstraintCheck();
        PointerMove();
    }

    private void ControlledMove()
    {
        rb.velocity = controlDirection * (moveSpeed * controlSpeedScaler);
    }

    private void PointerMove()
    {
        pointer.rotation = quaternion.AxisAngle(Vector3.forward,Mathf.Atan2(lookDirection.y,lookDirection.x));
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
        if (!immobilized)
        {
            rb.velocity = moveDirection * (moveSpeed * speedScaler);
        }

        //rb.velocity = immobilized ? Vector3.zero : moveDirection * (moveSpeed * speedScaler);
    }

    void OnFire()
    {
        if (currentPowerUp!= null)
        {
            currentPowerUp.Activate(this, lookDirection);
            currentPowerUp = null;
        }
    }

    public void Heal(int healing)
    {
        if (health<3)
        {
            health+= healing;
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0) 
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

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }

    public void AddPowerUp<T>()where T : BasePowerUp
    {
        currentPowerUp = gameObject.AddComponent<T>();
    }

    public bool HasPowerUp()
    {
        return currentPowerUp != null;
    }

    public string PowerUpName()
    {
        return HasPowerUp()? currentPowerUp.GetName():"";
    }

    public int GetHealth()
    {
        return health;
    }

    public void MakePermiable(float duration)
    {
        component.enabled = false;
        Invoke("MakeSolid",duration);
    }

    public void MakeSolid()
    {
        component.enabled = true;
    }

    public void Control(Vector2 direction,float duration,float speed)
    {
        beingControlled = true;
        controlDirection = direction;
        controlSpeedScaler = speed;
        Invoke("LoseControl",duration);
    }

    public void LoseControl()
    {
        beingControlled = false;
    }

    public bool TryGetPowerUp(out BasePowerUp basePowerUp)
    {
        basePowerUp = currentPowerUp;
        if (HasPowerUp())
        {
            return true;
        }
        return false;
    }

    public void UpdateSprite(int playerNumber)
    {
        playerSprite.sprite = GetComponent<PrefabHolder>().playerSprites[playerNumber];
    }
}
