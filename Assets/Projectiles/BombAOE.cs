using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAOE : MonoBehaviour
{
    [SerializeField] private float time = 2.5f;

    private void Start()
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.Damage(1);
                playerController.SpeedChange(0.5f,4f);
            }
        }
    }
}
