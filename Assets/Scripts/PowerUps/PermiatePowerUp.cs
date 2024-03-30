using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermiatePowerUp : BasePowerUp
{
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        pc.MakePermiable(4f);
    }

    public override string GetName()
    {
        return "Boost";
    }
}
