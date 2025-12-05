using global::UnityEngine;

public class EnemyShooting : UnityEngine.MonoBehaviour
{
    [UnityEngine.SerializeField] private UnityEngine.GameObject[] projectilePrefabs;
    [UnityEngine.SerializeField] private float minFireDelay = 1f;
    [UnityEngine.SerializeField] private float maxFireDelay = 5f;
    private float nextFireTime;
    private float timer;

    public UnityEngine.Transform projectilePos;
    global::ObjectPooling objectPool;

    public float projectileSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPool = UnityEngine.Object.FindAnyObjectByType<global::ObjectPooling>();
        //projectileSpeed = GameStats.instance.defaultProjectileSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            timer += UnityEngine.Time.deltaTime;
            if (timer >= nextFireTime)
            {
                Shoot();

                timer = 0f;
                nextFireTime = UnityEngine.Random.Range(minFireDelay, maxFireDelay);
            }
        }
    }

    void Shoot()
    {
        UnityEngine.GameObject projectileToSpawn = projectilePrefabs[UnityEngine.Random.Range(0, projectilePrefabs.Length)];
        UnityEngine.GameObject spawnedProjectile = objectPool.ActivateObject(projectileToSpawn);

        //spawnedProjectile.transform.position = transform.position;
        spawnedProjectile.transform.position = projectilePos.position;
        spawnedProjectile.transform.rotation = UnityEngine.Quaternion.identity;

        UnityEngine.Rigidbody2D obstacleRb = spawnedProjectile.GetComponent<UnityEngine.Rigidbody2D>();
        obstacleRb.linearVelocity = UnityEngine.Vector2.left * projectileSpeed;  // projectile moves from right to left.
    }
}
