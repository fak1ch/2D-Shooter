using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
public class AnimationController : MonoBehaviour
    {
        public event Action OnAnimationEnd;
        
        [SerializeField] private Animator _animator;
        
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private HealthComponent _healthComponent;
        
        private int _speedPercentHash;
        private int _dieTriggerHash;
        private int _takeDamageTriggerHash;
        private int _attackTriggerHash;
        
        private bool _takeDamageAnimationPlayed = false;

        private void Start()
        {
            _healthComponent.OnTakeDamage += PullTakeDamageTrigger;
            _healthComponent.OnHealthEqualsZero += PullDieTrigger;
            
            _speedPercentHash = Animator.StringToHash("SpeedPercent");
            _dieTriggerHash = Animator.StringToHash("DieTrigger");
            _takeDamageTriggerHash = Animator.StringToHash("TakeDamageTrigger");
            _attackTriggerHash = Animator.StringToHash("AttackTrigger");
        }

        private void Update()
        {
            _animator.SetFloat(_speedPercentHash, _movableComponent.SpeedPercent);
        }

        public void PullAttackTrigger()
        {
            PullAnimationTrigger(_attackTriggerHash);
        }

        private void PullTakeDamageTrigger(int damage)
        {
            if (_takeDamageAnimationPlayed)
            {
                EndTakeDamageAnimation();
                return;
            }
            
            _movableComponent.SetCanMove(false);
            OnAnimationEnd += EndTakeDamageAnimation;
            _takeDamageAnimationPlayed = true;
            
            PullAnimationTrigger(_takeDamageTriggerHash);
        }

        private void EndTakeDamageAnimation()
        {
            _movableComponent.SetCanMove(true);
            _takeDamageAnimationPlayed = false;
            OnAnimationEnd -= EndTakeDamageAnimation;
        }

        public void PullDieTrigger()
        {
            PullAnimationTrigger(_dieTriggerHash);
        }

        private void PullAnimationTrigger(int hash)
        {
            _animator.SetTrigger(hash);
        }

        private void UnityAnimationEndCallback()
        {
            OnAnimationEnd?.Invoke();
        }
    }
}