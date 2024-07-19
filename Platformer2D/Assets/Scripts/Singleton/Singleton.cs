using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Singleton

{
  public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
  {
        public T instance;

        private void Awake()
        {
            if (instance == null)
                instance = gameObject.AddComponent<T>();
            else
                Destroy(gameObject);

        }

  }



}
