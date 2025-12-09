using System;
using UnityEngine;

public class ObstacleCounter : MonoBehaviour
{
    private Vector3 localOffset;
    private PlayerStatus playerStatus;
    private HealthScript1 health;
    public int obstaclesPassed = 0;
    private void Awake()
    {
        localOffset = transform.localPosition;
        playerStatus = GetComponentInParent<PlayerStatus>();
        health = GetComponentInParent<HealthScript1>();
    }

    private void LateUpdate()
    {
        transform.position = transform.parent.position + localOffset;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && playerStatus.deathCardActive)
        {
            obstaclesPassed++;
            Debug.Log("Death Card = " + obstaclesPassed);
             if (obstaclesPassed == 13)
             {
                 Debug.Log("Damage Taken!");
                 
                 health.TakeDamage(1);
                 obstaclesPassed = 0;
                 playerStatus.deathCardActive = false;
             }
        }
        else if (other.CompareTag("Obstacle") && playerStatus.highPriestessActive)
        {
            obstaclesPassed++;
            Debug.Log("High Priestess = " + obstaclesPassed);
            if (obstaclesPassed == 2)
            {
                health.ReplenishHealth(1);
                obstaclesPassed = 0;
                playerStatus.highPriestessActive = false;
            }
        }
    }
}
