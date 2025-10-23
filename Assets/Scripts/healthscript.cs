using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class healthscript : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int damagePerHit = 1;
    private int currentHealth;

    [Header("UI (optional)")]
    [SerializeField] private Image fillImage;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        currentHealth = maxHealth;
        if (fillImage == null)
        {
            var go = GameObject.Find("HealthBar");
            if (go != null) fillImage = go.GetComponent<Image>();
        }
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")) HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject obstacle)
    {
        TakeDamage(damagePerHit);
        if (obstacle != null) Destroy(obstacle);
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0) return;
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        Debug.Log($"healthscript: Took {amount} damage. Health = {currentHealth}/{maxHealth}");
        UpdateUI();
        if (currentHealth <= 0) Die();
    }

    private void UpdateUI()
    {
        if (fillImage != null && maxHealth > 0)
            fillImage.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("healthscript: Player died.");
        Destroy(gameObject);
    }

}
