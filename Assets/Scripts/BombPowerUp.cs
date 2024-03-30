using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPowerUp : BasePowerUp
{
    [SerializeField] private GameObject BombPF;
    
    public override void Activate(PlayerController pc)
    {
        Vector2 lookDirection = pc.GetLookDirection();
        Bomb b = Instantiate(BombPF,pc.transform.position+new Vector3(lookDirection.x,lookDirection.y),Quaternion.identity).GetComponent<Bomb>();
        b.Setup(lookDirection,pc.gameObject);
        Destroy(this);
    }

    public override string GetName()
    {
        return "Bomb";
    }


    
}
