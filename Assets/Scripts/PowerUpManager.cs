using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private bool lockPowerUpForTesting;
    [SerializeField] private int powerUpToTest = 2;
    

    public void GivePowerUp(PlayerController pc)
    {
        int i = Random.Range(0, 9);
        if (lockPowerUpForTesting)
        {
            i = powerUpToTest;
        }
        switch (i)
        {
            case 0:
                pc.AddPowerUp<BombPowerUp>();
                break;
            case 1:
                pc.AddPowerUp<BoostPowerUp>();
                break;
            case 2:
                pc.AddPowerUp<SwappingPowerUp>();
                break;
            case 3:
                pc.AddPowerUp<ConfusionPowerUp>();
                break;
            case 4:
                pc.AddPowerUp<HookPowerUp>();
                break;
            case 5:
                pc.AddPowerUp<GragasUltPowerup>();
                break;
            case 6:
                pc.AddPowerUp<SlowAuraPowerUp>();
                break;
            case 7:
                pc.AddPowerUp<DefinetlyNotAniviaWall>();
                break;
            case 8:
                pc.AddPowerUp<DashSlashFlash>();
                break;
            case 9:
                pc.AddPowerUp<BulletBillPowerUp>();
                break;
            case 10:
                pc.AddPowerUp<PermiatePowerUp>();
                break;
            case 11:
                pc.AddPowerUp<ShootPowerUp>();
                break;
            default:
                pc.AddPowerUp<BombPowerUp>();
                break;
        }
    }

}
