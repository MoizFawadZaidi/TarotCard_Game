using global::UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private global::HealthScript1 playerHealth;
    [UnityEngine.SerializeField] private UnityEngine.UI.Image totalHealthBar;
    [UnityEngine.SerializeField] private UnityEngine.UI.Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.CurrentHealth / 3;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.CurrentHealth / 3;
    }
}
