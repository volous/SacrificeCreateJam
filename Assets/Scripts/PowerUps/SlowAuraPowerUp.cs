using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAuraPowerUp : BasePowerUp
{
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        pc.SpeedChange(2,1);
        pc.Heal(1);
        Destroy(this);
    }

    public override string GetName()
    {
        return "Boost";
    }
}
