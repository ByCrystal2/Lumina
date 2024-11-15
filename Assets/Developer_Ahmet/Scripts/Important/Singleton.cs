using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();

                    // Bu noktada Singleton<T> türüne dönüştürme yaparak IsPersistent çağırıyoruz
                    if ((singletonObject.GetComponent<T>() as Singleton<T>).IsPersistent())
                    {
                        DontDestroyOnLoad(singletonObject);
                    }
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            if (IsPersistent())
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    protected virtual bool IsPersistent()
    {
        return true; // Varsayılan olarak kalıcıdır, override edilerek değiştirilebilir
    }
}
