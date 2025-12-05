using Unity.VisualScripting;
using global::UnityEngine;
using UnityEngine.Rendering;

public class PrefabIdentifier : UnityEngine.MonoBehaviour
{
    [UnityEngine.HideInInspector] public UnityEngine.GameObject prefab;

    public void SetPrefab(UnityEngine.GameObject prefab)
    {
        this.prefab = prefab;
    }
}
