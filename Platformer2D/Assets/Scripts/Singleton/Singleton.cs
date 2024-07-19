using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Singleton

{
  public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
  {
        public static T Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = gameObject.AddComponent<T>();
            else
                Destroy(gameObject);

        }

  }



}