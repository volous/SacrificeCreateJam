using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionAOE : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController playerController))
            {
                playerController.SpeedChange(-playerController.moveSpeed, 4f);
            }
        }
    }
}
