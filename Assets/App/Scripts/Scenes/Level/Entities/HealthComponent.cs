using System;
using App.Scripts.General.Utils;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action OnHealthEqualsZero;
        public event Action OnHealthChanged;
        public event Action<int> OnTakeDamage;

        public float HealthPercent => MathUtils.GetPercent(0, MaxHealth, Health);
        public int MaxHealth { get; private set; }
        public int Health { get; private set; }

        private bool _isHealthEqualsZero = false;

        public void Initialize(int maxHealth)
        {
            MaxHealth = maxHealth;
            Health = MaxHealth;
        }

        public void TakeDamage(int value)
        {
            int health = Health;
            
            Health = Mathf.Clamp(Health - value,0, MaxHealth);

            SendHealthChangedEvent();
            CheckHealth();
            SendTakeDamageEvent(health - Health);
        }

        public void RestoreHealth(int value)
        {
            SendHealthChangedEvent();
            Health = Mathf.Clamp(Health + value,0, MaxHealth);
        }

        public void RestoreFullHealth()
        {
            SendHealthChangedEvent();
            Health = MaxHealth;
        }

        private void SendHealthChangedEvent()
        {
            if (Health > 0)
            {
                _isHealthEqualsZero = false;
            }
            
            OnHealthChanged?.Invoke();
        }

        private void SendTakeDamageEvent(int deltaDamage)
        {
            if (_isHealthEqualsZero == true) return;
            
            OnTakeDamage?.Invoke(deltaDamage);
        }
        
        private void CheckHealth()
        {
            if (_isHealthEqualsZero == true) return;
            
            if (Health == 0)
            {
                _isHealthEqualsZero = true;
                OnHealthEqualsZero?.Invoke();
            }
        }
    }
}