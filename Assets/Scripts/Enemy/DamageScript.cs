using global::System;
using global::UnityEngine;

public class DamageScript : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] public float damage;
    
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<global::HealthScript1>().TakeDamage(damage);
        }
    }
}
