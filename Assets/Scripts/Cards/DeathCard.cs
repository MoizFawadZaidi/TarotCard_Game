using System;
using UnityEngine;

public class DeathCard : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStatus>().TriggerDeathCardReveal();
            
            other.GetComponent<PlayerStatus>().deathCardActive = true;
            Debug.Log(gameObject.name + " has been triggered");
            gameObject.SetActive(false);
        }
    }
}
