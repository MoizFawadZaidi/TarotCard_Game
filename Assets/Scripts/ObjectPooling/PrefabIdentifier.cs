using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PrefabIdentifier : MonoBehaviour
{
    [HideInInspector] public GameObject prefab;

    public void SetPrefab(GameObject prefab)
    {
        this.prefab = prefab;
    }
}
