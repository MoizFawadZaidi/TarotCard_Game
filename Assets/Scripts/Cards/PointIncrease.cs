using System;
using Unity.VisualScripting;
using UnityEngine;

public class PointIncrease : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private AudioClip bonusPointsSoundClip;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundFXManager.instance.PlaySoundFXClip(bonusPointsSoundClip, transform, 0.1f);
            gameManager.currentScore += 5;
            gameObject.SetActive(false);
        }
    }
}
