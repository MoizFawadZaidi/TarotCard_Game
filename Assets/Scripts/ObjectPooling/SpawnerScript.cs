using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using global::UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private UnityEngine.Transform[] lanes;
    
    [UnityEngine.SerializeField] private UnityEngine.GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;
    private float timeUntilObstacleSpawn;
    
    [UnityEngine.SerializeField] private UnityEngine.GameObject[] cardPrefabs;
    public float cardSpawnTime = 2f;
    public float cardSpeed = 1f;
    private float timeUntilCardSpawn;

    global::ObjectPooling objectPool;

    private void Awake()
    {
        objectPool = UnityEngine.Object.FindAnyObjectByType<global::ObjectPooling>();
    }

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            SpawnLoop();
        }
    }

    // Time until the next obstacle spawns 
    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += UnityEngine.Time.deltaTime;
        timeUntilCardSpawn += UnityEngine.Time.deltaTime;

        // If the TimeUntilObstacleSpawn has reached the obstacleSpawnTime value then: spawn an obstacle and set timeUntilObstacleSpawn to 0.
        if (timeUntilObstacleSpawn >= obstacleSpawnTime) 
        {
            SpawnObstacle();
            timeUntilObstacleSpawn = 0f;
        }

        if (timeUntilCardSpawn >= cardSpawnTime)
        {
            SpawnCard();
            timeUntilCardSpawn = 0f;
        }
    }

    private void SpawnObstacle()
    {

        // Obstacle spawns at correct location, transform and rotation
        UnityEngine.GameObject obstacleToSpawn = obstaclePrefabs[UnityEngine.Random.Range(0, obstaclePrefabs.Length)];
        UnityEngine.GameObject spawnedObstacle = objectPool.ActivateObject(obstacleToSpawn);

        spawnedObstacle.transform.position = transform.position;
        spawnedObstacle.transform.rotation = UnityEngine.Quaternion.identity;

        UnityEngine.Rigidbody2D obstacleRb = spawnedObstacle.GetComponent<UnityEngine.Rigidbody2D>();
        obstacleRb.linearVelocity = UnityEngine.Vector2.left * obstacleSpeed;  // Obstacle moves from right to left.
    }

    private void SpawnCard()
    {
        // Cards spawning
        UnityEngine.GameObject cardToSpawn = cardPrefabs[UnityEngine.Random.Range(0, cardPrefabs.Length)];
        UnityEngine.GameObject spawnedCard = objectPool.ActivateObject(cardToSpawn);

        UnityEngine.Transform lane = lanes[UnityEngine.Random.Range(0, lanes.Length)];
        
        spawnedCard.transform.position = lane.position;
        spawnedCard.transform.rotation = UnityEngine.Quaternion.identity;

        UnityEngine.Rigidbody2D cardRb = spawnedCard.GetComponent<UnityEngine.Rigidbody2D>();
        cardRb.linearVelocity = UnityEngine.Vector2.left * cardSpeed;  // Obstacle moves from right to left.
    }
    
}
