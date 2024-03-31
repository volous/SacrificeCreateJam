using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject effectPF;
    [SerializeField] private float flyTime = 1.5f;
    [SerializeField] private float flySpeed = 2;
    
    [SerializeField] private GameObject owner;
    [SerializeField] private string AudioName;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject !=owner)
        {
            Explode();
        }
    }

    public void Explode(){
        if (AudioName != "")
            FindObjectOfType<AudioManager>().Play(AudioName);
        Instantiate(effectPF,transform.position,quaternion.identity);
        Destroy(gameObject);
    }

    public void Setup(Vector2 dir, GameObject pc)
    {
        GetComponent<Rigidbody2D>().velocity = dir* flySpeed;
        owner = pc;
        Invoke("Explode",flyTime);
    }
}
