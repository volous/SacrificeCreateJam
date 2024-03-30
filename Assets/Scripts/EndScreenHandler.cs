using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndScreenHandler : MonoBehaviour
{
    [SerializeField] private int sceneToLoad =0;
    
    private void Start()
    {
        
        Button restartButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("Restart");
        restartButton.clicked += Restart;
    }

    private void Restart()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
