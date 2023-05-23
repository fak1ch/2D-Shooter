using System;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private EnemyAIConfig _config;
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private AttackComponent _attackComponent;

        private Character _target;

        private void Update()
        {
            FindTarget();
            MoveToTarget();
            TryAttackTarget();
        }

        private void TryAttackTarget()
        {
            if(_target == null) return;

            float distance = Vector3.Distance(_target.transform.position, transform.position);
            if (distance <= _config.AttackDistance)
            {
                _attackComponent.StartAttack();
            }
        }
        
        private void MoveToTarget()
        {
            if(_target == null) return;

            Vector2 direction = (_target.transform.position - transform.position).normalized;
            _movableComponent.SetMoveInput(direction);
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
                    if (targetColliders[i].TryGetComponent(out Character character))
                    {
                        _target = character;
                        return;
                    }
                }
            }
        }

        #if UNITY_EDITOR
        
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, new Vector3(0, 0, 1), _config.AttackDistance);
            Handles.color = Color.blue;
            Handles.DrawWireDisc(transform.position, new Vector3(0, 0, 1), _config.TriggerRadius);
        }
        
        #endif
    }
}