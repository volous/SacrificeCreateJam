using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAura : MonoBehaviour
{
    private void Start()
    {
        Invoke("Remove",4);
    }

    public void Remove()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.SpeedChange(0.5f,4f);
            }
        }
    }
}
