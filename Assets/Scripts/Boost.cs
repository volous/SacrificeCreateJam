using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : BasePowerUp
{
    public override void Activate(PlayerController pc)
    {
        pc = GetComponent<PlayerController>();
        pc.SpeedChange(2,1);
        pc.Heal(1);
        Destroy(this);
    }

    public override string GetName()
    {
        return "Boost";
    }
}
