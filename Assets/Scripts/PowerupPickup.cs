using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class PowerupPickup : MonoBehaviour
{
    private PlayerController pc;
    private Boost _boostPower;
    private DefinetlyNotAniviaWall _wallPower;
    private GameObject _hitPowerupCube;
    
    [SerializeField] private List<BasePowerUp> _powerups;
    
    public BasePowerUp currentPowerUp;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
        _boostPower = GetComponent<Boost>();
        _wallPower = GetComponent<DefinetlyNotAniviaWall>();
        Debug.Log(_powerups.Count);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PowerUp")
        {
            var powerupSelector = Random.Range(0, _powerups.Count);
            pc.hasPowerup = true;
            _hitPowerupCube = col.gameObject;
            //destroy powerup cube
            currentPowerUp = _powerups[powerupSelector];
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
