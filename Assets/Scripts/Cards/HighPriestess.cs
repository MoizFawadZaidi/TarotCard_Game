using UnityEngine;

public class HighPriestess : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<PlayerStatus>().TriggerHighPriestessReveal();
            
            other.GetComponent<PlayerStatus>().highPriestessActive = true;
            Debug.Log(gameObject.name + " has been triggered");
            gameObject.SetActive(false);
        }
    }
}
