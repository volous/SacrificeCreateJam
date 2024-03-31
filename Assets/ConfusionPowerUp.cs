using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionPowerUp : BasePowerUp
{
    [SerializeField] private GameObject ConfusionPF;

    private void Start()
    {
        ConfusionPF = GetComponent<PrefabHolder>().ConfusionPF;
    }

    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        FindObjectOfType<AudioManager>().Play("Confusion");
        Confusion c = Instantiate(ConfusionPF, pc.transform.position + new Vector3(lookDirection.x, lookDirection.y), Quaternion.identity).GetComponent<Confusion>();
        c.Setup(lookDirection,pc.gameObject);
        Destroy(this);
    }

    public override string GetName()
    {
        return "Confusion";
    }
}
