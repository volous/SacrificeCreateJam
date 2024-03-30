using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;

    private Label _title;
    private Label _mainMenu;

    private Button _startButton;
    private Button _settingsButton;
    private Button _creditsButton;
    private Button _quitButton;
    
    
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        _document = GetComponent<UIDocument>();

        _startButton = _document.rootVisualElement.Q("StartButton") as Button;
        _startButton = _document.rootVisualElement.Q("SettingsButton") as Button;
        _startButton = _document.rootVisualElement.Q("CreditsButton") as Button;
        _startButton = _document.rootVisualElement.Q("QuitButton") as Button;
        
        _title = _document.rootVisualElement.Q("QuitButton") as Label;
        _mainMenu = _document.rootVisualElement.Q("QuitButton") as Label;
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
