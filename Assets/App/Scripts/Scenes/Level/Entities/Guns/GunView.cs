using System;
using App.Scripts.General.Utils;
using App.Scripts.Scenes.General;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.Scenes.MainScene.Entities.Bullets
{
    public class GunView : MonoBehaviour
    {
        [SerializeField] private Image _reloadBarImage;
        [SerializeField] private GameObject _reloadPanel;
        [SerializeField] private Gun _gun;

        private CustomTimer _reloadTimer;
        
        private void OnEnable()
        {
            _gun.OnReload += StartReloadView;
        }

        private void OnDisable()
        {
            _gun.OnReload -= StartReloadView;
        }

        private void Start()
        {
            _reloadPanel.SetActive(false);
            
            _reloadTimer = new CustomTimer();
            _reloadTimer.OnEnd += () =>
            {
                _reloadPanel.SetActive(false);
            };
        }

        private void Update()
        {
            _reloadTimer.Tick(Time.deltaTime);
            
            if (_reloadTimer.TimerStarted)
            {
                _reloadBarImage.fillAmount = MathUtils.GetPercent(0, _reloadTimer.MaxTime, _reloadTimer.CurrentTime);
            }
        }

        private void StartReloadView(float reloadTime)
        {
            _reloadPanel.SetActive(true);
            _reloadTimer.StartTimer(reloadTime);
        }
    }
}