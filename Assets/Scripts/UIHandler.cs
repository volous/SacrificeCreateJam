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
    [SerializeField] private Texture2D fireIcon,bombIcon, boostIcon,hookIcon,confusionIcon,slowIcon,boneWallIcon,dashIcon,bulletBillIcon,gragasUltIcon,ghostIcon,swapperIcon,healingIcon;

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

            Texture2D icon = fireIcon;
            if (pc.TryGetPowerUp(out BasePowerUp powerUp))
            {
                
                switch (powerUp)
                {
                    case BombPowerUp bombPowerUp:
                        icon = bombIcon;
                        break;
                    case BoostPowerUp boostPowerUp:
                        icon = boostIcon;
                        break;
                    case BulletBillPowerUp bulletBillPowerUp:
                        icon =bulletBillIcon;
                        break;
                    case ConfusionPowerUp confusionPowerUp:
                        icon =confusionIcon;
                        break;
                    case DashSlashFlash dashSlashFlash:
                        icon =dashIcon;
                        break;
                    case DefinetlyNotAniviaWall definetlyNotAniviaWall:
                        icon =boneWallIcon;
                        break;
                    case GragasUltPowerup gragasUltPowerup:
                        icon =gragasUltIcon;
                        break;
                    case HookPowerUp hookPowerUp:
                        icon =hookIcon;
                        break;
                    case PermiatePowerUp permiatePowerUp:
                        icon =ghostIcon;
                        break;
                    case ShootPowerUp shootPowerUp:
                        icon =healingIcon;
                        break;
                    case SlowAuraPowerUp slowAuraPowerUp:
                        icon =slowIcon;
                        break;
                    case SwapperPowerUp swapperPowerUp:
                        icon =swapperIcon;
                        break;
                    case SwappingPowerUp swappingPowerUp:
                        icon =swapperIcon;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(powerUp));
                }

            }
            
            ui.Q<VisualElement>("PowerUp").style.backgroundImage = pc.HasPowerUp()? new StyleBackground(icon): new StyleBackground(StyleKeyword.None);
        }
    }
}
