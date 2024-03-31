using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public bool gameEnded;
    [SerializeField] private GameObject endScreen,playerSelectScreen;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject countDown;
    

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Update()
    {
        if (!gameStarted &&Input.GetKey(KeyCode.Return))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        playerSelectScreen.SetActive(false);
        gameStarted = true;
        Instantiate(countDown);
        Invoke("Release",3);
    }

    public void Release()
    {
        
        playerManager.ReleasePlayers();
    }

    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            print("Game ended");
            endScreen.SetActive(true);
            playerManager.FreezePlayers();
        }
    }
}
