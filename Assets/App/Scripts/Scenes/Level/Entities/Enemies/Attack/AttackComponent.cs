using System;
using App.Scripts.Scenes.General;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private HitBox _hitBox;
        [SerializeField] private int _basicAttack;
        [SerializeField] private int _attackCooldown;

        private CustomTimer _attackCooldownTimer;

        private void Start()
        {
            _attackCooldownTimer = new CustomTimer();
            _attackCooldownTimer.OnEnd += EndAttack;
            _healthComponent.OnTakeDamage += TakeDamageCallback;
            _hitBox.OnTriggerEnter += HandleTriggerCollider2D;
        }
        
        private void Update()
        {
            _attackCooldownTimer.Tick(Time.deltaTime);
        }
        
        public void StartAttack()
        {
            if(_attackCooldownTimer.TimerStarted) return;
            _attackCooldownTimer.StartTimer(_attackCooldown);
            
            _movableComponent.SetCanMove(false);
            _hitBox.SetEnable(true);
            _animationController.OnAnimationEnd += EndAttack;
            _animationController.PullAttackTrigger();
        }

        private void EndAttack()
        {
            _movableComponent.SetCanMove(true);
            _hitBox.SetEnable(false);
        }

        private void TakeDamageCallback(int damage)
        {
            EndAttack();
        }
        
        private void HandleTriggerCollider2D(Collider2D col)
        {
            if(_attackCooldownTimer.TimerStarted) return;
            
            if (col.TryGetComponent(out Character character))
            {
                character.HealthComponent.TakeDamage(_basicAttack);
                _attackCooldownTimer.StartTimer(_attackCooldown);
            }
        }
    }
}