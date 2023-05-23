using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Entities.Rotations;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class CharacterEntityRotator : EntityRotator
    {
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private PlayerBodyRotation _playerBodyRotation;

        private float _moveInputX => _movableComponent.MoveInput.x;
        
        protected override void RotateEntity()
        {
            if (_playerBodyRotation.Target != null)
            {
                RotateEntityByTarget();
                return;
            }
            
            if (_moveInputX == 0) return;
            
            bool moveToRight = _moveInputX >= 0;

            if (moveToRight != _facingRight)
            {
                RotateTransform();
            }
        }

        private void RotateEntityByTarget()
        {
            Vector2 directionVector = _playerBodyRotation.Target.transform.position - transform.position;
            
            bool targetRight = directionVector.x >= 0;

            if (targetRight != _facingRight)
            {
                RotateTransform();
            }
        }
    }
}