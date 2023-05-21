using System;
using App.Scripts.General.UI.ButtonSpace;
using App.Scripts.Scenes.MainScene.Entities.SkillsModuleSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Input
{
    public class InputSystem : MonoBehaviour
    {
        public event Action OnShootButtonClicked;

        public Vector2 MoveInput { get; private set; }
        
        [SerializeField] private CustomButton _shootButton;
        [SerializeField] private Joystick _moveJoystick;
        
        [SerializeField] private LevelConfigScriptableObject levelConfig;

        #region Events

        private void OnEnable()
        {
            _shootButton.OnClickOccurred.AddListener(SendOnShootButtonClickedEvent);
        }

        private void OnDisable()
        {
            _shootButton.OnClickOccurred.RemoveListener(SendOnShootButtonClickedEvent);
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

        private void SendOnShootButtonClickedEvent()
        {
            OnShootButtonClicked?.Invoke();
        }
    }
}