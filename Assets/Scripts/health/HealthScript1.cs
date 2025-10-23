using UnityEngine;

public class HealthScript1 : MonoBehaviour
{
    public float currentHealth {  get; private set; }
    public float maxHealth = 3;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        
        if (currentHealth > 0)
        {
            // player recieve damage
        }
        else
        {
            // player death
            Destroy(gameObject);
        }
    }
}
