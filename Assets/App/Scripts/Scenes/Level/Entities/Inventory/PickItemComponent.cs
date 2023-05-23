using System;
using App.Scripts.Scenes.MainScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class PickItemComponent : MonoBehaviour
    {
        [SerializeField] private InventoryPopUp _inventoryPopUp;
        [SerializeField] private InputSystem _inputSystem;
        
        #region Events

        private void OnEnable()
        {
            _inputSystem.OnInventoryButtonClicked += _inventoryPopUp.ShowPopUp;
        }

        private void OnDisable()
        {
            _inputSystem.OnInventoryButtonClicked -= _inventoryPopUp.ShowPopUp;
        }

        #endregion
         
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item))
            {
                _inventoryPopUp.TryAddItem(item);
            }
        }
    }
}