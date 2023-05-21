using App.Scripts.Scenes.MainScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class PlayerGunInput : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private GunSlot _gunSlot;

        private void OnEnable()
        {
            _inputSystem.OnShootButtonClicked += Shoot;
            _inputSystem.OnReloadButtonClicked += Reload;
        }

        private void OnDisable()
        {
            _inputSystem.OnShootButtonClicked -= Shoot;
            _inputSystem.OnReloadButtonClicked -= Reload;
        }

        private void Shoot()
        {
            _gunSlot.Shoot();
        }

        private void Reload()
        {
            float reloadTime = _gunSlot.Reload();
        }
    }
}