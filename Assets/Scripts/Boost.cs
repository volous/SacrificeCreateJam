using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : BasePowerUp
{
    private PlayerController pc;
    public override void Activate()
    {
        pc = GetComponent<PlayerController>();
        pc.SpeedChange(2,1);
        pc.Heal(1);
    }

    
    public override void UI()
    {
        
    }
}
