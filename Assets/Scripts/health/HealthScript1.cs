using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class HealthScript1 : MonoBehaviour
{
    public float CurrentHealth { get; private set; }
    public float maxHealth = 3;
    [Header("iFrames")] 
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int flashCount;
    private SpriteRenderer spriteRend;


    [SerializeField] private AudioClip damageSoundClip;




    private void Awake()
    {
        CurrentHealth = maxHealth;
        
        spriteRend = GetComponent<SpriteRenderer>();
        




    }

    public void TakeDamage(float damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, maxHealth);


        if (CurrentHealth > 0)
        {
            // player recieve damage
            SoundFXManager.instance.PlaySoundFXClip(damageSoundClip, transform, 0.1f);
            StartCoroutine(Invulnerability());
            //Debug.Log(CurrentHealth);
        }
        else
        {
            // player death
            Destroy(gameObject);
            GameManager.instance.GameOver();

            PlayerPrefs.SetFloat("LastScoreFloat", GameManager.instance.currentScore);
            PlayerPrefs.Save();

            // Load the Death Scene (name must match your scene)
            SceneManager.LoadScene("DeathScene");

            




        }
    }
    private IEnumerator Invulnerability()
    {
        Debug.Log(iFramesDuration / flashCount *2);
        Physics2D.IgnoreLayerCollision(6, 7, true);
        Physics2D.IgnoreLayerCollision(6, 8, true);
        for (int i = 0; i < flashCount; i++)
        {
            
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / flashCount *2);
            spriteRend.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(iFramesDuration / flashCount *2);
            
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
   
}