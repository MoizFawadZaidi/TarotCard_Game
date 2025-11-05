using UnityEngine;

public class HealthScript1 : MonoBehaviour
{
    public float currentHealth { get; private set; }
    public float maxHealth = 3;

    [SerializeField] private AudioClip damageSoundClip;

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
            SoundFXManager.instance.PlaySoundFXClip(damageSoundClip, transform, 0.1f);
        }
        else
        {
            // player death
            Destroy(gameObject);
            GameManager.instance.GameOver();
        }
    }
}
