using System.Linq;
using App.Scripts.General.ObjectPool;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemyPoolContainer : PoolContainer<Enemy>
    {
        public EnemyPoolContainer(PoolObjectInformation<Enemy>[] poolObjectInfos, Transform poolContainer) : base(poolObjectInfos, poolContainer)
        {
            
        }
        
        public ObjectPool<Enemy> GetRandomPool()
        {
            var values = _pools.Values.ToList();
            int index = Random.Range(0, values.Count);
            return values[index];
        }
    }
}