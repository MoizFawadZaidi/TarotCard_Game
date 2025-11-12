using UnityEngine;

public class TheWorldCard : MonoBehaviour
{

    public Cards theWorld;
    SpawnerScript objectSpawner;
    EnemyShooting enemyShooting;

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
            objectSpawner.obstacleSpeed = theWorld.obsatcleSpeed;

            GameStats.instance.defaultProjectileSpeed = theWorld.projectileSpeed;

            foreach (var shooter in FindObjectsByType<EnemyShooting>(FindObjectsSortMode.None))
            {
                shooter.projectileSpeed = theWorld.projectileSpeed;
            }

            objectSpawner.obstacleSpawnTime = theWorld.obstacleSpawnTime;

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
