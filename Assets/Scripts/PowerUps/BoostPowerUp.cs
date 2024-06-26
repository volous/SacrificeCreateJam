using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerUp : BasePowerUp
{
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        pc.SpeedChange(2,1);
        pc.Heal(1);
    }

    public override string GetName()
    {
        return "Boost";
    }
}
