using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerCamera : MonoBehaviour
{
    [SerializeField] private List<Transform> players;

    public void Populate(List<Transform> newPlayers)
    {
        players = newPlayers;
    }
    private void Update()
    {
        foreach (Transform player in players)
        {
            if (player.position.x > transform.position.x +5 && transform.position.x<32.8f)    
            {
                transform.position = new Vector3(player.position.x -5,0,-10);
                foreach (Transform t in players)
                {
                    if (t.position.x < transform.position.x - 5)
                    {
                        t.position = new Vector3(transform.position.x-5,t.position.y,0);
                    }
                }
            }
        }
        
    }
}
