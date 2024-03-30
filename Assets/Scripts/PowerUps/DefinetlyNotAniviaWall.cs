using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DefinetlyNotAniviaWall : BasePowerUp
{
    private Vector2 aim;
    private List<Transform> _walls;
    public override void OnActivate(PlayerController pc,Vector2 lookDirection)
    {
        Instantiate(GetComponent<PrefabHolder>().walls[Random.Range(0, 1)], 
            pc.transform.position+new Vector3(lookDirection.x,lookDirection.y,0), 
            quaternion.identity);
    }

    public override string GetName()
    {
        return "Bone Wall";
    }
}
