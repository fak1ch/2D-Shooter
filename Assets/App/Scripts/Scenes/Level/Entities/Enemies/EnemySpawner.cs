using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyContainer _enemyContainer;
        [SerializeField] private List<Transform> _enemySpawnPoints;

        public void SpawnEnemyInRandomSpawnPoint()
        {
            Enemy enemy = _enemyContainer.GetEnemy();
            enemy.transform.position = GetRandomSpawnPoint().position;
            enemy.gameObject.SetActive(true);
        }

        private Transform GetRandomSpawnPoint()
        {
            int index = Random.Range(0, _enemySpawnPoints.Count);
            return _enemySpawnPoints[index];
        }
    }
}