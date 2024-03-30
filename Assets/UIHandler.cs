using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    VisualElement root;
    [SerializeField] private VisualTreeAsset playerUI;
    [SerializeField] private List<PlayerController> players;
    [SerializeField] private Dictionary<PlayerController,VisualElement> playersAndUI = new Dictionary<PlayerController, VisualElement>();
    
    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
    }

    public void AddPlayer(PlayerController pc)
    {
        VisualElement pUI =playerUI.Instantiate();
        root.Q<VisualElement>("Holder").Add(pUI);
        players.Add(pc);
        playersAndUI.Add(pc,pUI);
    }

    private void Update()
    {
        foreach (var (pc, ui) in playersAndUI)
        {
            ui.Q<Label>("PowerUpText").text = pc.PowerUpName();
            ui.Q<Label>("Health").text = "HP:" +pc.GetHealth();
        }
    }
}
