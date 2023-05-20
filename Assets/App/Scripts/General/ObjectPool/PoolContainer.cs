using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.General.ObjectPool
{
    public class PoolContainer<T> where T : Component
    {
        private readonly PoolObjectInformation<T>[] _objectsInfo;
        private readonly Transform _poolContainer;
        private readonly Dictionary<Type, ObjectPool<T>> pools;

        protected PoolContainer(PoolObjectInformation<T>[] poolObjectInfos, Transform poolContainer)
        {
            _poolContainer = poolContainer;
            pools = new Dictionary<Type, ObjectPool<T>>();
            _objectsInfo = poolObjectInfos;
            InitializePools();
        }
        
        private void InitializePools()
        {
            foreach (var info in _objectsInfo)
            {
                var poolData = new PoolData<T>
                {
                    size = info.PoolSize,
                    container = _poolContainer,
                    prefab = info.Prefab
                };
                
                pools.Add(info.Prefab.GetType(), new ObjectPool<T>(poolData));
            }
        }

        protected T GetObjectFromPoolByType(Type type)
        {
            return pools[type].GetElement();
        }

        protected void ReturnObjectToPool(T gameObject)
        {
            pools[gameObject.GetType()].ReturnElementToPool(gameObject);
        }
    }
}