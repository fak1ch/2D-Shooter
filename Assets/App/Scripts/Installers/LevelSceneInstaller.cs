using App.Scripts.General.PopUpSystemSpace;
using App.Scripts.Scenes;
using App.Scripts.Scenes.MainScene.Entities;
using App.Scripts.Scenes.MainScene.Entities.Bullets;
using App.Scripts.Scenes.MainScene.Entities.Enemies;
using UnityEngine;

namespace App.Scripts.Installers
{
    public class LevelSceneInstaller : Installer
    {
        [SerializeField] private LevelConfigScriptableObject _levelConfig;
        [SerializeField] private InventoryPopUp _inventoryPopUp;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyContainer _enemyContainer;
        [SerializeField] private GunSlot _gunSlot;
        [SerializeField] private Gun _makarov;
        
        private void Awake()
        {
            PopUpSystem.Instance.enabled = true;
            
            _inventoryPopUp.Initialize();
            _inventoryPopUp.TryAddItem(_makarov);
            _gunSlot.SelectGun(_makarov);
            
            _enemyContainer.Initialize();

            for (int i = 0; i < _levelConfig.StartEnemyCount; i++)
            {
                _enemySpawner.SpawnEnemyInRandomSpawnPoint();
            }
        }
    }
}