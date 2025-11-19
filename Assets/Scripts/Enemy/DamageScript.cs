using System;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthScript1>().TakeDamage(damage);
        }
    }
}
