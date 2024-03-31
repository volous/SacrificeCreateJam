using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPowerUp : BasePowerUp
{
    [SerializeField] private GameObject hookPF;

    private void Start()
    {
        hookPF = GetComponent<PrefabHolder>().HookPF;
    }

    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        Hook h = Instantiate(hookPF, pc.transform.position + new Vector3(lookDirection.x, lookDirection.y), Quaternion.identity).GetComponent<Hook>();
        h.Setup(lookDirection, pc.gameObject);
        Destroy(this);
    }

    public override string GetName()
    {
        return "Hook";
    }

}
