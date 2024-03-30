using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GragasUltPowerup : BasePowerUp
{
    [SerializeField] private GameObject barrelPF;

    private void Start()
    {
        barrelPF = GetComponent<PrefabHolder>().BarrelPF;
    }

    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        Barrel b = Instantiate(barrelPF, pc.transform.position + new Vector3(lookDirection.x, lookDirection.y), Quaternion.identity).GetComponent<Barrel>();
        b.Setup(lookDirection, pc.gameObject);
        Destroy(this);
    }

    public override string GetName()
    {
        return "Exploding Barrel";
    }
}
