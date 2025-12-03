using System;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private float damage;

    public bool hasHitPlayer  = false;
    
    private void Awake()
    {
        // objectPooling = ObjectPooling.instance;
    }
    
    // ObjectPooling objectPooling;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthScript1>().TakeDamage(damage);
            hasHitPlayer = true;
            // objectPooling.RemoveObject(gameObject);
        }
    }
}
