using App.Scripts.General.Utils;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.MovementSystem
{
    public class MovableComponent : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public float SpeedPercent => MathUtils.GetPercent(0, _maxSpeed, 
            _rigidbody2D.velocity.magnitude);
        
        [SerializeField] private MovableComponentConfig _config;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private Vector3 _targetPosition;
        private bool _moveToPosition = false;
        private bool _canMove = true;
        private int _canMoveCount = 0;
        private float _maxSpeed;

        private void Start()
        {
            _maxSpeed = Mathf.Max(_config.moveSpeedHorizontal, 
                _config.moveSpeedVertical) * Time.fixedDeltaTime;
        }

        private void FixedUpdate()
        {
            if (_moveToPosition)
            {
                MoveInput = (_targetPosition - transform.position).normalized;
                
                float sqrDistance = Vector2.SqrMagnitude(_targetPosition - transform.position);
                if (sqrDistance <= 0.01f)
                {
                    _moveToPosition = false;
                }
            }
            
            Move(MoveInput);
        }

        private void Move(Vector2 moveInput)
        {
            moveInput.x *= _config.moveSpeedHorizontal;
            moveInput.y *= _config.moveSpeedVertical;

            moveInput = _canMove ? moveInput : Vector2.zero;
            
            SetVelocity(moveInput * Time.deltaTime);
        }

        public void MoveToPosition(Vector3 position)
        {
            _moveToPosition = true;
            _targetPosition = position;
        }
        
        public void SetCanMove(bool value)
        {
            _canMoveCount += value ? 1 : - 1;
            _canMoveCount = Mathf.Clamp(_canMoveCount, _canMoveCount, 0);
            
            _canMove = _canMoveCount == 0;
            
            SetVelocity(Vector2.zero);
        }

        public void SetMoveInput(Vector2 moveInput)
        {
            MoveInput = moveInput;
        }
        
        private void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.velocity = velocity;
        }
    }
}