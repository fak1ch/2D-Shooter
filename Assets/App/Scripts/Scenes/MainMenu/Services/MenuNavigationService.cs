using System.Collections.Generic;
using UnityEngine;

public class MenuNavigationService : MonoBehaviour
{
    [SerializeField] private GameObject _shopScreen;
    [SerializeField] private GameObject _mainScreen;
    [SerializeField] private GameObject _briefingScreen;
    [SerializeField] private GameObject _talismanScreen;
    [SerializeField] private GameObject _gachaScreen;
    [SerializeField] private GameObject _questScreen;
    [SerializeField] private GameObject _mapScreen;
    
    [SerializeField] private GameObject _interactPanel;
    [SerializeField] private GameObject _statsPanel;

    private Dictionary<ScreenKey, GameObject> _screensMap;
    private Dictionary<CharacterPanelKey, GameObject> _characterPanelsMap;
    
    private GameObject _currentActiveScreen;
    private GameObject _currentActiveCharacterPanel;
    
    public void Initialize()
    {
        _screensMap = new Dictionary<ScreenKey, GameObject>
        {
            {ScreenKey.ShopScreen, _shopScreen},
            {ScreenKey.MainScreen, _mainScreen},
            {ScreenKey.BriefingScreen, _briefingScreen},
            {ScreenKey.TalismanScreen, _talismanScreen},
            {ScreenKey.GachaScreen, _gachaScreen},
            {ScreenKey.QuestScreen, _questScreen},
            {ScreenKey.MapScreen, _mapScreen}
        };

        _characterPanelsMap = new Dictionary<CharacterPanelKey, GameObject>
        {
            {CharacterPanelKey.StatsPanel, _statsPanel},
            {CharacterPanelKey.InteractPanel, _interactPanel}
        };

        _currentActiveScreen = _mainScreen;
        _currentActiveCharacterPanel = _interactPanel;
    }

    public void OpenScreen(ScreenKey key)
    {
        _currentActiveScreen.gameObject.SetActive(false);

        _currentActiveScreen = _screensMap[key];
        _currentActiveScreen.SetActive(true);
    }

    public void OpenCharacterPanel(CharacterPanelKey key)
    {
        if (_currentActiveScreen != _mainScreen)
        {
            return;
        }

        _currentActiveCharacterPanel.SetActive(false);
        
        _currentActiveCharacterPanel = _characterPanelsMap[key];
        _currentActiveCharacterPanel.SetActive(true);
    }

    public void OpenMainMenu()
    {
        OpenScreen(ScreenKey.MainScreen);
        OpenCharacterPanel(CharacterPanelKey.InteractPanel);
    }
}
