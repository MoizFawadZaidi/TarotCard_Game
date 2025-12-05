using System.Collections;
using global::UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class HealthScript1 : UnityEngine.MonoBehaviour
{
    public float CurrentHealth { get; private set; }
    public float maxHealth = 3;
    [UnityEngine.Header("iFrames")] 
    [UnityEngine.SerializeField] private float iFramesDuration;
    [UnityEngine.SerializeField] private int flashCount;
    private UnityEngine.SpriteRenderer spriteRend;

    [UnityEngine.SerializeField] private UnityEngine.AudioClip damageSoundClip;
    
    private void Awake()
    {
        CurrentHealth = maxHealth;
        spriteRend = GetComponent<UnityEngine.SpriteRenderer>();
    }
    
    public void ReplenishHealth(float replenishment)
    {
        CurrentHealth = UnityEngine.Mathf.Clamp(CurrentHealth + replenishment, 0, maxHealth);
        UnityEngine.Debug.Log("current health: " + CurrentHealth);
    }
    
    public void TakeDamage(float damage)
    {
        CurrentHealth = UnityEngine.Mathf.Clamp(CurrentHealth - damage, 0, maxHealth);


        if (CurrentHealth > 0)
        {
            // player receive damage
            SoundFXManager.instance.PlaySoundFXClip(damageSoundClip, transform, 0.1f);
            StartCoroutine(Invulnerability());
        }
        else
        {
            // player death
            UnityEngine.Object.Destroy(gameObject);
            GameManager.instance.GameOver();

            UnityEngine.PlayerPrefs.SetFloat("LastScoreFloat", GameManager.instance.currentScore);
            UnityEngine.PlayerPrefs.Save();

            // Load the Death Scene (name must match your scene)
            UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScene");
        }
    }
    private System.Collections.IEnumerator Invulnerability()
    {
        UnityEngine.Debug.Log(iFramesDuration / flashCount *2);
        UnityEngine.Physics2D.IgnoreLayerCollision(6, 7, true);
        UnityEngine.Physics2D.IgnoreLayerCollision(6, 8, true);
        for (int i = 0; i < flashCount; i++)
        {
            
            spriteRend.color = new UnityEngine.Color(1, 0, 0, 0.5f);
            yield return new UnityEngine.WaitForSeconds(iFramesDuration / flashCount *2);
            spriteRend.color = new UnityEngine.Color(1, 1, 1, 1);
            yield return new UnityEngine.WaitForSeconds(iFramesDuration / flashCount *2);
            
        }

        UnityEngine.Physics2D.IgnoreLayerCollision(6, 7, false);
        UnityEngine.Physics2D.IgnoreLayerCollision(6, 8, false);
    }


   
}