using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAuraPowerUp : BasePowerUp
{
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        Instantiate(GetComponent<PrefabHolder>().slowArea,pc.transform);
    }

    public override string GetName()
    {
        return "Slow Aura";
    }
}
