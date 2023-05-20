using UnityEngine;
using UnityEngine.UI;

public class MenuHotBarService : MonoBehaviour
{
    [SerializeField] private Button _backBtn;
    [SerializeField] private Button _shopBtn;
    [SerializeField] private Button _warningBtn;
    [SerializeField] private Button _giftBtn;
    [SerializeField] private Button _homeBtn;

    private MenuNavigationService _menuNavigationService;

    public void Initialize(MenuNavigationService menuNavigationService)
    {
        _menuNavigationService = menuNavigationService;
        AddListenersToButtons();
    }

    private void AddListenersToButtons()
    {
        //TODO переименовть кнопку или хз че сней делать
        _backBtn.onClick.AddListener(() =>
        {
            _menuNavigationService.OpenCharacterPanel(CharacterPanelKey.StatsPanel);
        });
        
        _homeBtn.onClick.AddListener(() =>
        {
            _menuNavigationService.OpenMainMenu();
        });
        
        _shopBtn.onClick.AddListener(() =>
        {
            _menuNavigationService.OpenScreen(ScreenKey.ShopScreen);
        });
        
        _warningBtn.onClick.AddListener(() =>
        {
            Debug.LogWarning("WARN");
        });
        
        _giftBtn.onClick.AddListener(() =>
        {
            Debug.Log("GIFT?");
        });
    }
}
