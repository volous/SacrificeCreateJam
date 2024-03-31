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
    [SerializeField] private Dictionary<PlayerController,VisualElement> playersAndUI = new();
    [SerializeField] private Texture2D fireIcon;

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
            //ui.Q<Label>("Health").text = "HP:" +pc.GetHealth();
            for (int i = 0; i < 4; i++)
            {
                ui.Q<VisualElement>("HP" + i).style.display = i == pc.GetHealth()? DisplayStyle.Flex:DisplayStyle.None;
            }
            ui.Q<VisualElement>("PowerUp").style.backgroundImage = pc.HasPowerUp()? new StyleBackground(fireIcon): new StyleBackground(StyleKeyword.None);
        }
    }
}
