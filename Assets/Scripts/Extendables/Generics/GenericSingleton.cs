using UnityEngine;

namespace Extendables.Generics
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }
	
        public virtual void Awake ()
        {
            if (Instance == null) 
            {
                Instance = this as T;
                DontDestroyOnLoad (this);
            } 
            else 
            {
                Destroy (gameObject);
            }
        }
    }
}