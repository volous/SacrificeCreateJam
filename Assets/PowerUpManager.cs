using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private bool lockPowerUpForTesting;
    [SerializeField] private int powerUpToTest = 2;
    

    public void GivePowerUp(PlayerController pc)
    {
        int i = Random.Range(0, 3);
        if (lockPowerUpForTesting)
        {
            i = powerUpToTest;
        }
        print(i);
        switch (i)
        {
            case 0:
                pc.AddPowerUp<BombPowerUp>();
                break;
            case 1:
                pc.AddPowerUp<Boost>();
                break;
            case 2:
                pc.AddPowerUp<SwappingPowerUp>();
                break;
            default:
                pc.AddPowerUp<BombPowerUp>();
                break;
        }
    }
}
