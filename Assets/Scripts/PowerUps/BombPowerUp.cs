using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class BombPowerUp : BasePowerUp
{
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        Instantiate(GetComponent<PrefabHolder>().BombPF,
           pc.transform.position+new Vector3(lookDirection.x,lookDirection.y),
           Quaternion.identity).GetComponent<Projectile>().Setup(lookDirection,pc.gameObject);
    }

    public override string GetName()
    {
        return "Bomb";
    }


    
}
