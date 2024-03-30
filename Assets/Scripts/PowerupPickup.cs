using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPickup : MonoBehaviour
{
    private PlayerController pc;
    private Boost _boostPower;
    private DefinetlyNotAniviaWall _wallPower;
    private GameObject _hitPowerupCube;
    private List<BasePowerUp> _powerups;
    private void Start()
    {
        pc = GetComponent<PlayerController>();
        _boostPower = GetComponent<Boost>();
        _wallPower = GetComponent<DefinetlyNotAniviaWall>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PowerUp")
        {
            pc.hasPowerup = true;
            _hitPowerupCube = col.gameObject;
            //destroy powerup cube
            Destroy(col.gameObject);
        }
    }
    
    //add which powerup it is on player
    private void GivePlayerPowerup()
    {
        if (pc.hasPowerup)
        {
            //get the different powerups
            
            
        }
    }
    
    
}
