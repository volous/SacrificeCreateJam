using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")||col.CompareTag("AI"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
