using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : BasePowerUp
{
    private PlayerController pc;
    public override void Activate()
    {
        pc = GetComponent<PlayerController>();
        pc.speedScaler = 2;
        pc.AddHealth();
        Invoke("EndEffect",2);
    }

    void EndEffect()
    {
        pc.speedScaler = 1;
        Destroy(this);
    }

    public override void UI()
    {
        throw new System.NotImplementedException();
    }
}
