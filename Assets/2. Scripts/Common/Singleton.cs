using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    private static T instacne;

    public static T Instance
    {
        get
        {
            if (instacne == null)
            {
                instacne = FindFirstObjectByType<T>();
                if (instacne == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instacne = obj.AddComponent<T>();
                }
            }
            return instacne;
        }
    }

    private void Awake()
    {
        if (instacne == null)
        {
            instacne = this as T;
            DontDestroyOnLoad(this.gameObject);

            SceneManager.sceneLoaded += OnSceneLoad;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    protected abstract void OnSceneLoad(Scene arg0, LoadSceneMode arg1);
}