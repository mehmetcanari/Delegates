using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mehmetcanari.CodeVault
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; protected set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                throw new System.Exception("An instance of this singleton already exists.");
            }
            else
            {
                Instance = (T)this;
            }
        }
    }
}

