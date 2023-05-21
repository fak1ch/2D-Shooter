using System;
using App.Scripts.General.ObjectPool;
using App.Scripts.Scenes.General;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Bullets
{
    [Serializable]
    public class GunConfig
    {
        public float ShootingSpeed = 1;
        public float ReloadTime = 1;
        public int AmmoSize = 8;
        public Transform BulletStartPoint;
        public PoolData<Bullet> BulletPoolData;
    }
    
    public class Gun : MonoBehaviour
    {
        public event Action<float> OnReload;
        public float ReloadTime => _config.ReloadTime;
        
        [SerializeField] private GunConfig _config;
        
        private CustomTimer _shootingTimer;
        private CustomTimer _reloadTimer;
        private ObjectPool<Bullet> _bulletPool;

        private int _ammoCount;

        private void Start()
        {
            _shootingTimer = new CustomTimer();
            _reloadTimer = new CustomTimer();
            _bulletPool = new ObjectPool<Bullet>(_config.BulletPoolData);
            
            _ammoCount = _config.AmmoSize;
            _reloadTimer.OnEnd += () =>
            {
                _ammoCount = _config.AmmoSize;
            };
        }

        private void Update()
        {
            _shootingTimer.Tick(Time.deltaTime);
            _reloadTimer.Tick(Time.deltaTime);
        }

        public void Shoot(bool entityRotatorFacingRight)
        {
            if(_reloadTimer.TimerStarted) return;
            if(_shootingTimer.TimerStarted) return;
            _shootingTimer.StartTimer(_config.ShootingSpeed);
            
            Bullet bullet = _bulletPool.GetElement();
            bullet.Initialize(_bulletPool, transform.eulerAngles, _config.BulletStartPoint.position, entityRotatorFacingRight);

            _ammoCount--;
            if (_ammoCount <= 0)
            {
                Reload();
            }
        }

        public void Reload()
        {
            if(_reloadTimer.TimerStarted) return;
            _reloadTimer.StartTimer(_config.ReloadTime);
            
            OnReload?.Invoke(_config.ReloadTime);
        }
    }
}