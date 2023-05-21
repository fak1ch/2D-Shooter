using System;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class PlayerMoveInput : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private MovableComponent _movableComponent;

        private void Update()
        {
            _movableComponent.SetMoveInput(_inputSystem.MoveInput);
        }
    }
}