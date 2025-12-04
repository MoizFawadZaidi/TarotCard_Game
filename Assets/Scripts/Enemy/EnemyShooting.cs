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

    public float projectileSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPool = FindAnyObjectByType<ObjectPooling>();
        //projectileSpeed = GameStats.instance.defaultProjectileSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            timer += Time.deltaTime;
            if (timer >= nextFireTime)
            {
                Shoot();

                timer = 0f;
                nextFireTime = Random.Range(minFireDelay, maxFireDelay);
            }
        }
    }

    void Shoot()
    {
        GameObject projectileToSpawn = projectilePrefabs[Random.Range(0, projectilePrefabs.Length)];
        GameObject spawnedProjectile = objectPool.ActivateObject(projectileToSpawn);

        //spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.transform.position = projectilePos.position;
        spawnedProjectile.transform.rotation = Quaternion.identity;

        Rigidbody2D obstacleRb = spawnedProjectile.GetComponent<Rigidbody2D>();
        obstacleRb.linearVelocity = Vector2.left * projectileSpeed;  // projectile moves from right to left.
    }
}
