using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class Character : MonoBehaviour
    {
        public HealthComponent HealthComponent => _healthComponent;
        
        [SerializeField] private HealthComponent _healthComponent;
    }
}