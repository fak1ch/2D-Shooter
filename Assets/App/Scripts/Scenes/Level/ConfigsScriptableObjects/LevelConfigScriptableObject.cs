using App.Scripts.Scenes.MainScene.Input;
using UnityEngine;

namespace App.Scripts.Scenes
{
    [CreateAssetMenu(menuName = "App/MainSceneConfig", fileName = "MainSceneConfig")]
    public class LevelConfigScriptableObject : ScriptableObject
    {
        public InputSystemConfig InputSystemConfig;
    }
}