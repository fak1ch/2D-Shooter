using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class MoveInputEntityRotator : EntityRotator
    {
        [SerializeField] private MovableComponent _movableComponent;

        private float _moveInputX => _movableComponent.MoveInput.x;
        
        protected override void RotateEntity()
        {
            if (_moveInputX == 0) return;
            
            bool moveToRight = _moveInputX >= 0;

            if (moveToRight != _facingRight)
            {
                RotateTransform();
            }
        }
    }
}