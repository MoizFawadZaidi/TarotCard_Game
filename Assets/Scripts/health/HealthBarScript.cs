using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private HealthScript1 playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 3;
    }
}
