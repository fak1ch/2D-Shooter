using UnityEngine;
using UnityEngine.UI;

public class MenuOffersService : MonoBehaviour
{
    [SerializeField] private Button _VIPBtn;
    [SerializeField] private Button _CalendarBtn;
    [SerializeField] private Button _ClipBtn;
    [SerializeField] private Button _CasinoBtn;
    [SerializeField] private Button _OtherFirstBtn;
    [SerializeField] private Button _OtherSecondBtn;

    private MenuNavigationService _navigationService;

    public void Initialize(MenuNavigationService navigationService)
    {
        _navigationService = navigationService;

        LoadOffersData();
        SetOffersView();


        AddListenersToButtons();
    }

    private void LoadOffersData()
    {
    }

    private void SetOffersView()
    {
    }

    private void AddListenersToButtons()
    {
        _VIPBtn.onClick.AddListener(() => { Debug.Log("Vip Pressed"); });

        _CalendarBtn.onClick.AddListener(() => { Debug.Log("Calendar Pressed"); });

        _ClipBtn.onClick.AddListener(() => { Debug.Log("Clip Pressed"); });

        _CasinoBtn.onClick.AddListener(() => { Debug.Log("Casino Pressed"); });

        _OtherFirstBtn.onClick.AddListener(() => { Debug.Log("Other first Pressed"); });

        _OtherSecondBtn.onClick.AddListener(() => { Debug.Log("Other Second Pressed"); });
    }
}