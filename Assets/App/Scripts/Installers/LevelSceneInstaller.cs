using App.Scripts.General.PopUpSystemSpace;
using App.Scripts.Scenes.MainScene.Input;
using App.Scripts.Scenes.MainScene.Map;
using UnityEngine;

namespace App.Scripts.Installers
{
    public class LevelSceneInstaller : Installer
    {
        [SerializeField] private InputSystem _inputSystem;

        [Space(10)]
        [SerializeField] private FollowCamera _followCamera;
 
        private void Awake()
        {
            PopUpSystem.Instance.enabled = true;
        }
    }
}