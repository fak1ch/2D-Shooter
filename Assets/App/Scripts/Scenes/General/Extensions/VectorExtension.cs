using System;
using UnityEngine;

namespace App.Scripts.Scenes.General.Extensions
{
    public static class VectorExtension
    {
        public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
        {
            vector.x = Math.Clamp(vector.x, min.x, max.x);
            vector.y = Math.Clamp(vector.y, min.y, max.y);
            vector.z = Math.Clamp(vector.z, min.z, max.z);

            return vector;
        }
        
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}