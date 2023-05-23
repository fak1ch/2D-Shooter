using System;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class HitBox : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerEnter;

        [SerializeField] private Collider2D _collider2D;

        private void Start()
        {
            SetEnable(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            OnTriggerEnter?.Invoke(col);
        }

        public void SetEnable(bool value)
        {
            _collider2D.enabled = value;
        }
    }
}