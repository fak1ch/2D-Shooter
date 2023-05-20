using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.MainMenu.Services
{
    public class MenuTalismanService : MonoBehaviour
    {
        [SerializeField] private Button _startScreenBtn;
        [SerializeField] private List<Button> _buttonsScrollList;
        [SerializeField] private Button _selectBtn;
        [SerializeField] private Button _upgradeBtn;
        [SerializeField] private TextMeshProUGUI _descriptionTMP;
        
        private MenuNavigationService _navigationService;
      
        public void Initialize(MenuNavigationService navigationService)
        {
            _navigationService = navigationService;
            AddListenersToButtons();
        }
        
        private void AddListenersToButtons()
        {
            _startScreenBtn.onClick.AddListener(()=>
            {
                _navigationService.OpenScreen(ScreenKey.TalismanScreen);
            });
        }
    }
}