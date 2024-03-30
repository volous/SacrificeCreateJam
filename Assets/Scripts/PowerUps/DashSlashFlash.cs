using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSlashFlash : BasePowerUp
{
    
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        pc.gameObject.transform.position += new Vector3(lookDirection.x, lookDirection.y, 0) * 1.5f;
    }

    public override string GetName()
    {
        return "Flash";
    }
}
