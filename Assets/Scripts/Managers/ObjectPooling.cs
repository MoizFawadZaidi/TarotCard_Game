using global::System;
using System.Collections.Generic;
using Unity.Mathematics;
using global::UnityEngine;

public class ObjectPooling : UnityEngine.MonoBehaviour
{
    public static global::ObjectPooling instance;

    private System.Collections.Generic.Dictionary<UnityEngine.GameObject, System.Collections.Generic.Queue<UnityEngine.GameObject>> pools = new System.Collections.Generic.Dictionary<UnityEngine.GameObject, System.Collections.Generic.Queue<UnityEngine.GameObject>>();

    public UnityEngine.GameObject topLaneObstacles;
    public UnityEngine.GameObject middleLaneObstacles;
    public UnityEngine.GameObject bottomLaneObstacles;
    public UnityEngine.GameObject pointIncrease;
    public UnityEngine.GameObject deathCard;
    public UnityEngine.GameObject highPriestessCard;
    [UnityEngine.SerializeField] private UnityEngine.GameObject[] projectilePrefabs;

    
    private void Awake()
    {
        if (ObjectPooling.instance == null)
        {
            ObjectPooling.instance = this;
        }
        else
        {
            UnityEngine.Object.Destroy(gameObject);
        }
    }

    private void Start()
    {
        CreatePool(topLaneObstacles, 6);
        CreatePool(bottomLaneObstacles, 6);
        CreatePool(middleLaneObstacles, 6);
        CreatePool(pointIncrease, 3);
        CreatePool(deathCard, 3);
        CreatePool(highPriestessCard, 3);
        
        foreach (UnityEngine.GameObject prefab in projectilePrefabs)
        {
            CreatePool(prefab, 10);
        }
        
    }

    private void CreatePool(UnityEngine.GameObject prefab, int poolsize)
    {
        System.Collections.Generic.Queue<UnityEngine.GameObject> newPool = new System.Collections.Generic.Queue<UnityEngine.GameObject>();
        for (int i = 0; i < poolsize; i++)
        {
            UnityEngine.GameObject obj = UnityEngine.Object.Instantiate(prefab, transform);
            obj.GetComponent<global::PrefabIdentifier>().SetPrefab(prefab);
            obj.SetActive(false);
            newPool.Enqueue(obj);
        }
        pools[prefab] = newPool;
    }

    public UnityEngine.GameObject ActivateObject (UnityEngine.GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
        {
            UnityEngine.Debug.LogWarning($"No pools found for{prefab.name}");
            return null;
        }

        System.Collections.Generic.Queue<UnityEngine.GameObject> pool = pools[prefab];
        UnityEngine.GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            // Dynamically expand pool
            obj = UnityEngine.Object.Instantiate(prefab, transform);
            obj.GetComponent<global::PrefabIdentifier>().SetPrefab(prefab);
        }

        obj.SetActive(true);
        return obj;
    }
    public void RemoveObject(UnityEngine.GameObject obj)
    {
        obj.SetActive(false);
        UnityEngine.GameObject prefab = obj.GetComponent<global::PrefabIdentifier>().prefab;

        if (pools.ContainsKey(prefab))
            pools[prefab].Enqueue(obj);
        else
            UnityEngine.Debug.LogWarning($"Trying to return object to a non-existing pool: {prefab.name}");
    }
}


