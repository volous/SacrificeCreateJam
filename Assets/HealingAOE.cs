using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingAOE : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.Heal(1);
            }
        }
    }
}
