using UnityEngine;
using UnityEngine.UI;

public class MenuLevelService : MonoBehaviour
{
    [SerializeField] private Button _startLvl;
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _levelOne;
    
    private MenuNavigationService _navigationService;

    public void Initialize(MenuNavigationService navigationService)
    {
        _navigationService = navigationService;
        AddListenersToButtons();
    }

    private void AddListenersToButtons()
    {
        _startLvl.onClick.AddListener(()=>{Debug.Log("Load Level");});

        _playBtn.onClick.AddListener(() => { _navigationService.OpenScreen(ScreenKey.MapScreen); });
        _levelOne.onClick.AddListener(()=>{_navigationService.OpenScreen(ScreenKey.BriefingScreen);});
    }

    private void SetUpBriefing()
    {
        //TODO Тут нужно убдет прокинуть конфиг брифинга для уровня
    }
}
