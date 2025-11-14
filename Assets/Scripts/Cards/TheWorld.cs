using System.Collections;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    SpawnerScript spawnerScript;
    EnemyShooting enemyShooting;
    public Cards theWorld;
    GameStats stats;
    public float obstacleSpeed;
    public float projectileSpeed;
    public float effectDuration;
    private bool isActivated;
    private Coroutine slowMotionCoroutine;

    private void Start()
    {
        spawnerScript = FindAnyObjectByType<SpawnerScript>();
        enemyShooting = FindAnyObjectByType<EnemyShooting>();
        stats = FindAnyObjectByType<GameStats>();
    }

    private void Update()
    {
        if (isActivated) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SlowMotion());
        }
    }

    IEnumerator SlowMotion()
    {
        yield return null;
        // Slow motion effect starts
        Debug.Log("Effect started!");
        isActivated = true;

        // spawn time for obstacle increases
        spawnerScript.obstacleSpawnTime *= theWorld.multiplierOrHalfing;

        // Obsatcles move slow
        foreach (var obstacle in FindObjectsByType<SpawnerScript>(FindObjectsSortMode.None))
        {
            spawnerScript.obstacleSpeed /= theWorld.multiplierOrHalfing;
        }

        var obstacles = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);
        foreach (var rb in obstacles)
        {
            if (rb.CompareTag("Obstacle"))
            {
                rb.linearVelocity = Vector2.left * theWorld.obsatcleSpeed;
            }
        }

        // Projectiles move slow
        GameStats.instance.defaultProjectileSpeed = theWorld.projectileSpeed;

        foreach (var projectile in FindObjectsByType<EnemyShooting>(FindObjectsSortMode.None))
        {
            projectile.projectileSpeed = projectile.projectileSpeed / theWorld.multiplierOrHalfing;
        }

        var projectiles = FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None);
        foreach (var rb in projectiles)
        {
            if (rb.CompareTag("Projectile"))
            {
                rb.linearVelocity = Vector2.left * theWorld.projectileSpeed;
            }
        }

        // Slow motion effect ends
        yield return new WaitForSeconds (effectDuration);
        Debug.Log("Effect ended!");
        //isActivated = false;

        //if (isActivated == false)
        //{
        //    Destroy(gameObject);
        //}

        //spawnerScript.obstacleSpeed = stats.defaultObstacleSpeed;

        //enemyShooting.projectileSpeed = stats.defaultProjectileSpeed;

    }
}
