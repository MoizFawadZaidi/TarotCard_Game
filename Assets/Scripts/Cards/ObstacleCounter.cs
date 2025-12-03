using System;
using UnityEngine;

public class ObstacleCounter : MonoBehaviour
{
    DamageScript damageScript;
    float obstaclesPassed;
    
    [SerializeField] private GameObject[] obstaclePrefabs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        damageScript = FindAnyObjectByType<DamageScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject obstacle in obstaclePrefabs)
        {
            if (damageScript.hasHitPlayer == false)
            {
                obstaclesPassed++;
            }
        }
    }
}
