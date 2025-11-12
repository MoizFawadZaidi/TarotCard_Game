using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject[] projectilePrefabs;
    [SerializeField] private float minFireDelay = 1f;
    [SerializeField] private float maxFireDelay = 5f;
    private float nextFireTime;
    private float timer;

    public Transform projectilePos;
    ObjectPooling objectPool;
    GameStats stats;
    public float projectileSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPool = FindAnyObjectByType<ObjectPooling>();
        projectileSpeed = GameStats.instance.defaultProjectileSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= nextFireTime)
            {
                shoot();

                timer = 0f;
                nextFireTime = Random.Range(minFireDelay, maxFireDelay);
            }
        }
    }

    void shoot()
    {
        GameObject projectileToSpawn = projectilePrefabs[Random.Range(0, projectilePrefabs.Length)];
        GameObject spawnedProjectile = objectPool.ActivateObject(projectileToSpawn);

        //spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.transform.position = projectilePos.position;
        spawnedProjectile.transform.rotation = Quaternion.identity;

        Rigidbody2D obstacleRB = spawnedProjectile.GetComponent<Rigidbody2D>();
        obstacleRB.linearVelocity = Vector2.left * projectileSpeed;  // projectile moves from right to left.
    }
}
