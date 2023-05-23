using App.Scripts.Scenes.MainScene.Entities.Enemies;
using App.Scripts.Scenes.MainScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Rotations
{
    public class PlayerBodyRotation : MonoBehaviour
    {
        public Enemy Target { get; private set; }

        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Transform _body;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;
        [SerializeField] private PlayerBodyRotationConfig _config;
        [SerializeField] private SpriteRenderer _circle;
        [SerializeField] private float _yOffset = 0.2f;

        private void Update()
        {
            FindTarget();
            RotateBody();
            DrawCircle();
        }

        private void DrawCircle()
        {
            Color color = Target == null ? Color.white : Color.green;
            _circle.color = color;
        }

        private void RotateBody()
        {
            Vector2 rotateDirection = new Vector2(0, 1);
            
            if (Target == null)
            {
                if (_inputSystem.MoveInput.Equals(Vector2.zero) == false)
                {
                    rotateDirection = _inputSystem.MoveInput;
                }
            }
            else
            {
                Vector3 targetPosition = Target.transform.position;
                targetPosition.y -= _yOffset;
                Vector2 distance = transform.position - targetPosition;
                rotateDirection = distance.normalized;
            }
            
            Quaternion newRotation = Quaternion.Slerp(_body.transform.rotation, 
                Quaternion.LookRotation(rotateDirection), Time.deltaTime * _levelConfig.BodyRotateSpeed);
            Vector3 eulerAngles = newRotation.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.y = 0;
            
            _body.transform.eulerAngles = eulerAngles;
        }
        
        private void FindTarget()
        {
            if (Target != null)
            {
                if (Target.IsDie)
                {
                    Target = null;
                }
                else
                {
                    return;
                }
            }

            Collider2D[] targetColliders = new Collider2D[4];
            int targetCollidersSize = Physics2D.OverlapCircleNonAlloc(transform.position, _config.TriggerRadius, targetColliders);

            if (targetCollidersSize > 0)
            {
                for (int i = 0; i < targetCollidersSize; i++)
                {
                    if (targetColliders[i].TryGetComponent(out Enemy enemy))
                    {
                        if(enemy.IsDie) continue;
                        
                        Target = enemy;
                        return;
                    }
                }
            }
            else
            {
                Target = null;
            }
        }
    }
}