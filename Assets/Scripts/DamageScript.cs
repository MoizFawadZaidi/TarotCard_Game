using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthScript1>().TakeDamage(damage);
        }
    }
}
