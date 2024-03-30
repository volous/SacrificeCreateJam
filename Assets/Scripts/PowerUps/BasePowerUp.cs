using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePowerUp : MonoBehaviour
{

    public void Activate(PlayerController pc, Vector2 lookDirection)
    {
        OnActivate(pc,lookDirection);
        Destroy(this);
    }
    public abstract void OnActivate(PlayerController pc, Vector2 lookDirection);

    public abstract String GetName();

}
