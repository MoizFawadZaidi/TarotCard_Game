using global::System;
using global::UnityEngine;

public class ObstacleCounter : UnityEngine.MonoBehaviour
{
    private UnityEngine.Vector3 localOffset;
    private global::PlayerStatus playerStatus;
    private global::HealthScript1 health;
    public int obstaclesPassed = 0;
    private void Awake()
    {
        localOffset = transform.localPosition;
        playerStatus = GetComponentInParent<global::PlayerStatus>();
        health = GetComponentInParent<global::HealthScript1>();
    }

    private void LateUpdate()
    {
        transform.position = transform.parent.position + localOffset;
    }
    
    
    private void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        if (other.CompareTag("Obstacle") && playerStatus.deathCardActive)
        {
            obstaclesPassed++;
            UnityEngine.Debug.Log("Death Card = " + obstaclesPassed);
             if (obstaclesPassed == 13)
             {
                 UnityEngine.Debug.Log("Damage Taken!");
                 
                 health.TakeDamage(1);
                 obstaclesPassed = 0;
                 playerStatus.deathCardActive = false;
             }
        }
        else if (other.CompareTag("Obstacle") && playerStatus.highPriestessActive)
        {
            obstaclesPassed++;
            UnityEngine.Debug.Log("High Priestess = " + obstaclesPassed);
            if (obstaclesPassed == 2)
            {
                //Debug.Log("Health Replenish!");
                
                health.ReplenishHealth(1);
                obstaclesPassed = 0;
                playerStatus.highPriestessActive = false;
            }
        }
    }
}
