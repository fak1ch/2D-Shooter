﻿using App.Scripts.Scenes.MainScene.Entities.Bullets;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class GunSlot : MonoBehaviour
    {
        [SerializeField] private Gun _selectedGun;
        [SerializeField] private Transform _gunPoint;
        [SerializeField] private EntityRotator _entityRotator;

        public void SelectGun(Gun gun)
        {
            if (_selectedGun != null)
            {
                _selectedGun.gameObject.SetActive(false);
            }

            _selectedGun = gun;
            gun.transform.SetParent(_gunPoint);
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.identity;
            gun.gameObject.SetActive(true);
        }

        public void Shoot()
        {
            if(_selectedGun == null) return;
            
            _selectedGun.Shoot(_entityRotator.FacingRight);
        }

        public float Reload()
        {
            if (_selectedGun == null) return 0;
            
            _selectedGun.Reload();
            
            return _selectedGun.ReloadTime;
        }
    }
}