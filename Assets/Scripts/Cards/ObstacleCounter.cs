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
            //ActivateEffect();
            
            obstaclesPassed++;
            Debug.Log("Number of obstacles passed =" + obstaclesPassed);
             if (obstaclesPassed == 13)
             {
                 Debug.Log("Damage Taken!");
                 
                 health.TakeDamage(1);
                 obstaclesPassed = 0;
                 playerStatus.deathCardActive = false;
             }
        }
    }
}
