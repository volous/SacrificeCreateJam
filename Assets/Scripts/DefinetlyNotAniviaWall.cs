using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class DefinetlyNotAniviaWall : BasePowerUp
{
    [SerializeField] private List<GameObject> _wall;
    private Vector2 aim;
    private PlayerController pc;
    private List<Transform> _walls;
    public override void Activate(PlayerController pc1)
    {
        pc = GetComponent<PlayerController>();
        //need to add the aim and some distance once that is implemented
        var selectRandomWall = Random.Range(0, 2);
        var _newWall = Instantiate(_wall[selectRandomWall], pc.transform.position, pc.transform.rotation);
        _wall.Add(_newWall);
    }

    public override string GetName()
    {
        return "Bone Wall";
    }
}
