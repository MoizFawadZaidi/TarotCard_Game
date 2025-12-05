using global::System;
using Unity.VisualScripting;
using global::UnityEngine;

public class PointIncrease : UnityEngine.MonoBehaviour
{
    private global::GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.currentScore += 5;
            gameObject.SetActive(false);
        }
    }
}
