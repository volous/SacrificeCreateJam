using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameEnded;



    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            print("Game ended");
        }
    }
}
