using global::System;
using global::UnityEngine;

public class DeathCard : UnityEngine.MonoBehaviour
{
    
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<global::PlayerStatus>().deathCardActive = true;
            UnityEngine.Debug.Log(gameObject.name + " has been triggered");
            gameObject.SetActive(false);
        }
    }
}
