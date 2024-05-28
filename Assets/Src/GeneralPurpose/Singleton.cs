// Codigo de la asignatura presenta en las diapositivas sobre el patrón singleton


using UnityEngine;

namespace GeneralPurpose
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else
            { 
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}

