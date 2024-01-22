using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance = null;
    public static UnityEvent<IPool> OnObjectPooled = new UnityEvent<IPool>();
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
