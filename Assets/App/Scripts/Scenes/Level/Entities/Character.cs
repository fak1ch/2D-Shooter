﻿using System;
using System.Collections;
using App.Scripts.General.LoadScene;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class Character : MonoBehaviour
    {
        public HealthComponent HealthComponent => _healthComponent;
        
        [SerializeField] private HealthComponent _healthComponent;

        private void Start()
        {
            _healthComponent.OnHealthEqualsZero += CharacterDieCallback;
        }

        private void CharacterDieCallback()
        {
            gameObject.SetActive(false);
            StartCoroutine(RestartSceneRoutine());
        }

        private IEnumerator RestartSceneRoutine()
        {
            yield return new WaitForSeconds(2f);
            SceneLoader.Instance.LoadScene(SceneEnum.Level);
        }
    }
}