using System;
using App.Scripts.Scenes.PauseManager;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public abstract class EntityRotator : MonoBehaviour, IPaused
    {
        public bool FacingRight => _facingRight;
        
        [SerializeField] protected bool _facingRight = true;

        private bool _onPause = false;

        private void Update()
        {
            if (_onPause == true) return;
            
            RotateEntity();
        }

        protected abstract void RotateEntity();

        protected void RotateTransform()
        {
            _facingRight = !_facingRight;
            
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

        public void SetPause(bool value)
        {
            _onPause = value;
        }
    }
}