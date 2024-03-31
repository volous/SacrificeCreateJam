using UnityEngine;

public class ShootPowerUp : BasePowerUp
{

   
    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        Instantiate(GetComponent<PrefabHolder>().healingPotion,
            pc.transform.position+new Vector3(lookDirection.x,lookDirection.y),
            Quaternion.identity).GetComponent<Projectile>()
            .Setup(lookDirection,pc.gameObject);
        
    }

    public override string GetName()
    {
        return "Healing Potion";
    }


    
}
