using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBillPowerUp : BasePowerUp
{
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        pc.Control(Vector2.right, 4,4f);
    }

    public override string GetName()
    {
        return "Bullet Bill";
    }
}
