using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPowerUp : BasePowerUp
{
    [SerializeField] private GameObject BombPF;
    
    public override void Activate(PlayerController pc)
    {
        Bomb b = Instantiate(BombPF,pc.transform.position,Quaternion.identity).GetComponent<Bomb>();
        b.Setup(pc.GetLookDirection(),pc.gameObject);
        Destroy(this);
    }

    
    public override void UI()
    {
        
    }
}
