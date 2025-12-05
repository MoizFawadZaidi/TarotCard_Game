using global::UnityEngine;
using UnityEngine.UI;

[UnityEngine.RequireComponent(typeof(UnityEngine.Rigidbody2D))]
public class Healthscript : UnityEngine.MonoBehaviour
{
    [UnityEngine.Header("Health")]
    [UnityEngine.SerializeField] private int maxHealth = 3;
    [UnityEngine.SerializeField] private int damagePerHit = 1;
    private int currentHealth;

    [UnityEngine.Header("UI (optional)")]
    [UnityEngine.SerializeField] private UnityEngine.UI.Image fillImage;

    private void Awake()
    {
        var rb = GetComponent<UnityEngine.Rigidbody2D>();
        if (rb == null) rb = gameObject.AddComponent<UnityEngine.Rigidbody2D>();
        rb.bodyType = UnityEngine.RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.constraints = UnityEngine.RigidbodyConstraints2D.FreezeRotation;

        currentHealth = maxHealth;
        if (fillImage == null)
        {
            var go = UnityEngine.GameObject.Find("HealthBar");
            if (go != null) fillImage = go.GetComponent<UnityEngine.UI.Image>();
        }
        UpdateUI();
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Obstacle")) HandleHit(other.gameObject);
    }

    private void HandleHit(UnityEngine.GameObject obstacle)
    {
        TakeDamage(damagePerHit);
        if (obstacle != null) UnityEngine.Object.Destroy(obstacle);
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0) return;
        currentHealth = UnityEngine.Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        UnityEngine.Debug.Log($"healthscript: Took {amount} damage. Health = {currentHealth}/{maxHealth}");
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
        UnityEngine.Debug.Log("healthscript: Player died.");
        UnityEngine.Object.Destroy(gameObject);
    }

}
