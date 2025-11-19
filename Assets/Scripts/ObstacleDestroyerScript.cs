using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleDestroyerScript : MonoBehaviour
{
    private void Awake()
    {
        objectPooling = ObjectPooling.instance;
    }

    ObjectPooling objectPooling;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if  (collision.CompareTag("Wall"))
        {
            objectPooling.RemoveObject(gameObject);
            Debug.Log("Object destroyed");
        }
    }
}
