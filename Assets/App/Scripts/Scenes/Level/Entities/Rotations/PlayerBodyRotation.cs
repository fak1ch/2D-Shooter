using System;
using App.Scripts.Scenes.MainScene.Entities.Enemies;
using App.Scripts.Scenes.MainScene.Input;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Rotations
{
    public class PlayerBodyRotation : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private Transform _body;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;
        [SerializeField] private PlayerBodyRotationConfig _config;

        private Enemy _target;

        private void Update()
        {
            FindTarget();
            RotateBody();
        }

        private void RotateBody()
        {
            Vector2 rotateDirection = new Vector2(0, 1);
            
            if (_target == null)
            {
                if (_inputSystem.MoveInput.Equals(Vector2.zero) == false)
                {
                    rotateDirection = _inputSystem.MoveInput;
                }
            }
            else
            {
                Vector2 distance = transform.position - _target.transform.position;
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
            if(_target != null) return;

            Collider2D[] targetColliders = new Collider2D[4];
            int targetCollidersSize = Physics2D.OverlapCircleNonAlloc(transform.position, _config.TriggerRadius, targetColliders);

            if (targetCollidersSize > 0)
            {
                for (int i = 0; i < targetCollidersSize; i++)
                {
                    if (targetColliders[i].TryGetComponent(out Enemy enemy))
                    {
                        _target = enemy;
                        return;
                    }
                }
            }
        }

        private void DrawCircle(SceneView view)
        {
            Handles.color = _target == null ? Color.white : Color.green;
            
            Handles.DrawWireDisc(transform.position, new Vector3(0, 0, 1), _config.TriggerRadius);
        }
    }
}