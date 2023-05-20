using App.Scripts.Scenes.MainMenu.Services;
using UnityEngine;

public class MainMenuContext : MonoBehaviour
{
    [SerializeField] private MenuOffersService _menuOffersService;
    [SerializeField] private MenuNavigationService _menuNavigationService;
    [SerializeField] private MenuTalismanService _menuTalismanService;
    [SerializeField] private MenuHotBarService _menuHotBarService;
    [SerializeField] private MenuLevelService _menuLevelService;
    
    private void Start()
    {
        DebugAssert();
        InitializeAllServices();
    }

    private void DebugAssert()
    {
        _menuNavigationService = GetComponent<MenuNavigationService>();
        _menuOffersService = GetComponent<MenuOffersService>();
        _menuTalismanService = GetComponent<MenuTalismanService>();
        _menuHotBarService = GetComponent<MenuHotBarService>();
        _menuLevelService = GetComponent<MenuLevelService>();
    }
    
    private void InitializeAllServices()
    {
        _menuNavigationService.Initialize();
        
        _menuLevelService.Initialize(_menuNavigationService);
        _menuTalismanService.Initialize(_menuNavigationService);
        _menuOffersService.Initialize(_menuNavigationService);
        _menuHotBarService.Initialize(_menuNavigationService);
        
        _menuNavigationService.OpenMainMenu();
    }
}
