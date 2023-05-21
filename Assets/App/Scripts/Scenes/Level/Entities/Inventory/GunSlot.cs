using App.Scripts.Scenes.MainScene.Entities.Bullets;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class GunSlot : MonoBehaviour
    {
        [SerializeField] private Gun _selectedGun;
        [SerializeField] private EntityRotator _entityRotator;

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