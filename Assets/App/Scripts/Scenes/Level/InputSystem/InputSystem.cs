using System;
using App.Scripts.General.UI.ButtonSpace;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Input
{
    public class InputSystem : MonoBehaviour
    {
        public event Action OnReloadButtonClicked;
        public event Action OnInventoryButtonClicked;

        public Vector2 MoveInput { get; private set; }
        public bool ShootButtonHold { get; private set; }
        
        [SerializeField] private CustomButton _shootButton;
        [SerializeField] private CustomButton _reloadButton;
        [SerializeField] private CustomButton _openInventoryButton;
        [SerializeField] private Joystick _moveJoystick;

        #region Events

        private void OnEnable()
        {
            _reloadButton.OnClickOccurred.AddListener(SendOnReloadButtonClickedEvent);
            _openInventoryButton.OnClickOccurred.AddListener(SendOnInventoryButtonClickedEvent);
            
            _shootButton.OnMouseDown.AddListener(() =>
            {
                ShootButtonHold = true;
            });
            
            _shootButton.OnMouseUp.AddListener(() =>
            {
                ShootButtonHold = false;
            });
        }

        private void OnDisable()
        {
            _reloadButton.OnClickOccurred.RemoveListener(SendOnReloadButtonClickedEvent);
            _openInventoryButton.OnClickOccurred.RemoveListener(SendOnInventoryButtonClickedEvent);
        }

        #endregion

        private void Update()
        {
            bool desktopInputSelected = false;

            #if UNITY_EDITOR
                float inputHorizontal = UnityEngine.Input.GetAxisRaw(AxisOptions.Horizontal.ToString());
                float inputVertical = UnityEngine.Input.GetAxisRaw(AxisOptions.Vertical.ToString());

                Vector2 moveInput = new Vector2(inputHorizontal, inputVertical);
                
                if (inputHorizontal != 0 || inputVertical != 0)
                {
                    desktopInputSelected = true;
                    SetMoveInput(moveInput);
                }
            #endif
 
            if (desktopInputSelected == false)
            {
                SetMoveInput(_moveJoystick.Direction);
            }
        }

        private void SetMoveInput(Vector2 input)
        {
            MoveInput = input;
        }

        private void SendOnReloadButtonClickedEvent()
        {
            OnReloadButtonClicked?.Invoke();
        }
        
        private void SendOnInventoryButtonClickedEvent()
        {
            OnInventoryButtonClicked?.Invoke();
        }
    }
}