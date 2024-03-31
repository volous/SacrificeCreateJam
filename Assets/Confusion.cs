using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confusion : MonoBehaviour
{
    [SerializeField] private GameObject confusionAOEPF;
    [SerializeField] private float flyTime = .5f;
    [SerializeField] private float flySpeed = 2;

    [SerializeField] private GameObject owner;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * flySpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.gameObject != owner)
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.SpeedChange(-playerController.moveSpeed / 4, 4f);
                Destroy(gameObject);
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject != owner)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(confusionAOEPF, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/

    public void Setup(Vector2 dir, GameObject pc)
    {
        GetComponent<Rigidbody2D>().velocity = dir * flySpeed;
        owner = pc;
        Destroy(gameObject, flyTime);
    }
}
