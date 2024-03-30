using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerController> players = new ();
    [SerializeField] private int numberOfPlayers;
    [SerializeField] private MultiplayerCamera multiCam;


    private void Start()
    {
        multiCam = FindObjectOfType<MultiplayerCamera>();
    }

    public void AddPlayer(PlayerController pc)
    {
        players.Add(pc);
        pc.Immobilize();
        numberOfPlayers++;
        pc.transform.position = new Vector3(-5,5-(numberOfPlayers*2),0);
    }

    public void ReleasePlayers()
    {
        List<Transform> transforms = new List<Transform>();
        foreach (PlayerController playerController in players)
        {
            playerController.Mobilize();
            transforms.Add(playerController.transform);
        }
        multiCam.Populate(transforms);
    }

    public void FreezePlayers()
    {
        foreach (PlayerController playerController in players)
        {
            playerController.Immobilize();
        }
    }
}
