using System;
using App.Scripts.Scenes.General;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> OnEnemyDie;
        
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private HitBox _hitBox;
        [SerializeField] private EnemyAI _enemyAI;
        
        #region Events

        private void OnEnable()
        {
            _healthComponent.OnHealthEqualsZero += HealthEqualsZeroCallback;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthEqualsZero -= HealthEqualsZeroCallback;
        }

        #endregion

        private void HealthEqualsZeroCallback()
        {
            _movableComponent.enabled = false;
            _hitBox.gameObject.SetActive(false);
            _enemyAI.enabled = false;
            //OnEnemyDie?.Invoke(this);
        }
    }
}