using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwappingPowerUp : BasePowerUp
{
    private Vector2 _currentPlayerPos;
    private Vector2 _closestPlayerPos;
    private List<PlayerController> players;
    private Vector2 initialPosition;
    private void Start()
    {
        Debug.Log(FindObjectsOfType<PlayerController>()[0].transform.position);
        Debug.Log(FindObjectsOfType<PlayerController>()[1].transform.position);
    }

    public override void OnActivate(PlayerController pc, Vector2 lookDirection)
    {
        initialPosition = transform.position;
        for (int i = 0; i < 5; i++)
        {
            players = FindObjectsOfType<PlayerController>().ToList();
        }
        
        var lowestDist = Mathf.Infinity;
        PlayerController closestPlayer = null;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].gameObject != this.gameObject)
            {
                float dist = Vector2.Distance(players[i].transform.position, transform.position);
                if (dist < lowestDist)
                {
                    lowestDist = dist;
                    closestPlayer = players[i];
                    
                    // Vector2 temp = transform.position;
                    // _closestPlayerPos = players[i].transform.position;
                    // transform.position = _closestPlayerPos;
                    // players[i].transform.position = temp;
                }
            }
            
        }

        if (closestPlayer != null)
        {
            Vector2 temp = initialPosition; // Use the stored initial position
            initialPosition = closestPlayer.transform.position; // Update the initial position for the next iteration
            transform.position = initialPosition;
            closestPlayer.transform.position = temp;
        }
        
        Destroy(this);
    }

    public override string GetName()
    {
        return "Swap";
    }
}
