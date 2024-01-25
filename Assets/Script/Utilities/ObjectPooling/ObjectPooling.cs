using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
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
    public T PopObjectFormPool<T>(List<T> pool, string Name, string path, bool show) where T : MonoBehaviour, IPool, new()
    {
        return PopFromPool(pool, Name, path, show);
    }
    private T PopFromPool<T>(List<T> pool, string objectName, string path, bool show) where T : MonoBehaviour, IPool, new()
    {
        // Logic để lấy 1 vật thể từ pool ra

        T obj = pool.Find(e => e.objectName.Equals(objectName));
        if (obj == null)
        {
            GameObject objAsset = Addressables.LoadAssetAsync<GameObject>(string.Format(path, objectName)).WaitForCompletion();
            objAsset.name = objectName;
            GameObject newObj = Instantiate(objAsset, transform);
            T value = newObj.GetComponent<T>();
            if (show)
                value.Show();
            pool.Remove(obj);
            return value;
        }
        if (show)
            obj.Show();
        pool.Remove(obj);
        return obj;
    }
    private void PushToPool<T>(T objectToPush, List<T> pool) where T : MonoBehaviour, IPool, new()
    {
        //if (pool.Contains(objectToPush))
        //    return;
        objectToPush.transform.SetParent(transform, true);
        pool.Add(objectToPush);
    }
}
