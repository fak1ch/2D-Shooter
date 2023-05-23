using UnityEngine;

namespace App.Scripts.Scenes
{
    [CreateAssetMenu(menuName = "App/LevelSceneConfig", fileName = "LevelSceneConfig")]
    public class LevelConfigScriptableObject : ScriptableObject
    {
        public float BodyRotateSpeed = 40f;
        public int StartEnemyCount;
    }
}