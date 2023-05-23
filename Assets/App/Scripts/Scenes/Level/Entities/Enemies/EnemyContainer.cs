using System;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.General.ObjectPool;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemyContainer : MonoBehaviour
    {
        [SerializeField] private PoolObjectInformation<Enemy>[] _poolObjectInformation;
        [SerializeField] private Transform _container;
        
        private EnemyPoolContainer _poolContainer;
        private readonly List<Enemy> _activeEnemies = new();

        public void Initialize()
        {
            _poolContainer = new EnemyPoolContainer(_poolObjectInformation, _container);
        }

        public Enemy GetEnemy()
        {
            Enemy enemy = _poolContainer.GetRandomPool().GetElement();
            enemy.OnEnemyDie += ReturnEnemyToPool;
            _activeEnemies.Add(enemy);

            return enemy;
        }

        private void ReturnEnemyToPool(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.OnEnemyDie -= ReturnEnemyToPool;
            _activeEnemies.Remove(enemy);
            _poolContainer.ReturnObjectToPool(enemy);
        }

        public Enemy GetNearestActiveEnemy(Vector3 targetPosition)
        {
            Enemy nearestEnemy = _activeEnemies.First();
            float minDistance = float.PositiveInfinity;

            for (int i = 1; i < _activeEnemies.Count; i++)
            {
                float distance = Vector3.Distance(_activeEnemies[i].transform.position, targetPosition);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = _activeEnemies[i];
                }
            }

            return nearestEnemy;
        }
    }
}