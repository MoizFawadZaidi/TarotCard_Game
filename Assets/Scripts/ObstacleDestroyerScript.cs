using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleDestroyerScript : MonoBehaviour
{
    private void Awake()
    {
        objectPooling = ObjectPooling.instance;
    }

    ObjectPooling objectPooling;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Wall")
        {
            objectPooling.RemoveObject(gameObject);
            //Debug.Log("Object destroyed");
        }
    }
}
