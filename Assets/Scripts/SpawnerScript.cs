using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    private float timeUntilObstacleSpawn;

    ObjectPooling objectPool;

    private void Awake()
    {
        objectPool = FindAnyObjectByType<ObjectPooling>();
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
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime) //If the TimeUntilObstacleSpawn has reached the obstacleSpawnTime value then: spawn an obstacle and set timeUntilObstacleSpawn to 0.
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {

        // Obstacle spawns at correct location, transform and rotation
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = objectPool.ActivateObject(obstacleToSpawn);

        spawnedObstacle.transform.position = transform.position;
        spawnedObstacle.transform.rotation = Quaternion.identity;


        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * obstacleSpeed;  // Obstacle moves from right to left.
    }
}
