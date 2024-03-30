using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerController> players = new ();
    [SerializeField] private int numberOfPlayers;
    [SerializeField] private MultiplayerCamera multiCam;
    [SerializeField] private UIHandler uiHandler;
    

    private void Start()
    {
        multiCam = FindObjectOfType<MultiplayerCamera>();
        uiHandler = GetComponent<UIHandler>();
    }

    public void AddPlayer(PlayerController pc)
    {
        players.Add(pc);
        pc.Immobilize();
        pc.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        numberOfPlayers++;
        pc.transform.position = new Vector3(-5,5-(numberOfPlayers*2),0);
        uiHandler.AddPlayer(pc);
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
            playerController.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
