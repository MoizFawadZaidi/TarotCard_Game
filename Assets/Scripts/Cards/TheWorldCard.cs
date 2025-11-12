using UnityEngine;

public class TheWorldCard : MonoBehaviour
{

    public Cards theWorld;
    public float duration = 5f;

    private SpawnerScript objectSpawner;
    private EnemyShooting enemyShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectSpawner = FindAnyObjectByType<SpawnerScript>();
        enemyShooting = FindAnyObjectByType<EnemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(theWorld.cardName);

            // Increase obstacle spawn time
            objectSpawner.obstacleSpawnTime = objectSpawner.obstacleSpawnTime * theWorld.multiplierOrHalfing;

            // Increase projectile spawn time


            // Obstacle speed decrease
            GameStats.instance.defaultProjectileSpeed = theWorld.projectileSpeed;

            foreach (var obstacle in FindObjectsByType<SpawnerScript>(FindObjectsSortMode.None))
            {
                objectSpawner.obstacleSpeed = objectSpawner.obstacleSpeed / theWorld.multiplierOrHalfing;
            }

            var obstacles = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);
            foreach (var rb in obstacles)
            {
                if (rb.CompareTag("Obstacle"))
                {
                    rb.linearVelocity = Vector2.left * theWorld.obsatcleSpeed;
                }
            }

            // Projectile speed decrease
            GameStats.instance.defaultProjectileSpeed = theWorld.projectileSpeed;

            foreach (var projectile in FindObjectsByType<EnemyShooting>(FindObjectsSortMode.None))
            {
                projectile.projectileSpeed = projectile.projectileSpeed/theWorld.multiplierOrHalfing;
            }

            var projectiles = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);

            foreach (var rb in projectiles)
            {
                if (rb.CompareTag("Projectile"))
                {
                    rb.linearVelocity = Vector2.left * theWorld.projectileSpeed;
                }
            }
        }
    }
}
