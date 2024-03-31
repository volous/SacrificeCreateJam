using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenHandler : MonoBehaviour
{
    void Start()
    {
        GetComponent<UIDocument>().rootVisualElement.Q<Button>("PlayButton").clicked += StartGame;
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
