using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class PowerupPickup : MonoBehaviour
{
    private GameObject _hitPowerupCube;
    
    [SerializeField] private PowerUpManager powerUpManager;
    [SerializeField] private PowerupSpawn _powerupSpawn;
    

    private void Start()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>();
        _powerupSpawn = FindObjectOfType<PowerupSpawn>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController pc)&& !pc.HasPowerUp())
            {
                powerUpManager.GivePowerUp(pc);
                Destroy(gameObject);
            }
            
        }
        
        
        
    }
}
