using global::System;
using System.Runtime.CompilerServices;
using global::UnityEngine;

public class ObstacleDestroyerScript : UnityEngine.MonoBehaviour
{
    
    private void Awake()
    {
        objectPooling = ObjectPooling.instance;
    }

    global::ObjectPooling objectPooling;
    private void OnTriggerEnter2D (UnityEngine.Collider2D collision)
    {
        if  (collision.CompareTag("Wall"))
        {
            objectPooling.RemoveObject(gameObject);
        }
    }
}
