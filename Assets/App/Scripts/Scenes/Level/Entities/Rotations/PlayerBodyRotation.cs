using System;
using App.Scripts.Scenes.MainScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Rotations
{
    public class PlayerBodyRotation : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Transform _body;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;

        private void Update()
        {
            Vector2 moveInput = _inputSystem.MoveInput.Equals(Vector2.zero) ? new Vector2(0, 1) : _inputSystem.MoveInput;
            
            Quaternion newRotation = Quaternion.Slerp(_body.transform.rotation, 
                Quaternion.LookRotation(moveInput), Time.deltaTime * _levelConfig.BodyRotateSpeed);
            Vector3 eulerAngles = newRotation.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.y = 0;
            
            _body.transform.eulerAngles = eulerAngles;
        }
    }
}