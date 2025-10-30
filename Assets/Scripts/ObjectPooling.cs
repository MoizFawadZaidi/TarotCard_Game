using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    private Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();

    public GameObject topLaneObstacles;
    public GameObject bottomLaneObstacles;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CreatPool(topLaneObstacles, 6);
        CreatPool(bottomLaneObstacles, 6);
    }

    private void CreatPool(GameObject prefab, int Poolsize)
    {
        Queue<GameObject> newPool = new Queue<GameObject>();
        for (int i = 0; i < Poolsize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.GetComponent<PrefabIdentifier>().SetPrefab(prefab);
            obj.SetActive(false);
            newPool.Enqueue(obj);
        }
        pools[prefab] = newPool;
    }

    public GameObject ActivateObject (GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            Debug.LogWarning($"No pools dound for{prefab.name}");
            return null;
        }

        Queue<GameObject> pool = pools[prefab];
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            //Dynamically expand pool
            obj = Instantiate(prefab, transform);
            obj.GetComponent<PrefabIdentifier>().SetPrefab(prefab);
        }

        obj.SetActive(true);
        return obj;
    }
    public void RemoveObject(GameObject obj)
    {
        obj.SetActive(false);
        GameObject prefab = obj.GetComponent<PrefabIdentifier>().prefab;

        if (pools.ContainsKey(prefab))
            pools[prefab].Enqueue(obj);
        else
            Debug.LogWarning($"Trying to return object to a non-existing pool: {prefab.name}");
    }
}


