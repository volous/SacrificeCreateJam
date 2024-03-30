using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePowerUp : MonoBehaviour
{
    public abstract void Activate(PlayerController pc);

    public abstract String GetName();

}
