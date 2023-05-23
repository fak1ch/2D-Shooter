using System;
using App.Scripts.Scenes.General;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> OnEnemyDie;
        public bool IsDie { get; private set; }
        
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private HitBox _hitBox;
        [SerializeField] private EnemyAI _enemyAI;
        [SerializeField] private Collider2D _hurtCollider;
        
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
            if(IsDie) return;
            IsDie = true;
            
            _movableComponent.SetCanMove(false);
            _movableComponent.enabled = false;
            _hitBox.gameObject.SetActive(false);
            _enemyAI.enabled = false;
            _hurtCollider.enabled = false;
            //OnEnemyDie?.Invoke(this);
        }
    }
}