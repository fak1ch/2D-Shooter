#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.General.LoadScene
{
    public partial class SceneInformation : ISerializationCallbackReceiver
    {
        public SceneAsset scene;
        
        public void OnBeforeSerialize()
        {
            if (scene != null)
            {
                sceneName = scene.name;
            }
            else
            {
                sceneName = String.Empty;
            }
        }

        public void OnAfterDeserialize()
        {
            
        }
    }

    [Serializable]
    public partial class SceneInformation
    {
        public SceneEnum sceneEnumEnum;
        public string sceneName;
    }
}

#endif