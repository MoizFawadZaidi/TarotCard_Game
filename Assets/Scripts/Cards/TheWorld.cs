using System.Collections;
using global::UnityEngine;

public class TheWorld : UnityEngine.MonoBehaviour
{
    global::SpawnerScript spawnerScript;
    global::EnemyShooting enemyShooting;
    public global::Cards theWorld;
    global::GameStats stats;
    public float obstacleSpeed;
    public float projectileSpeed;
    public float effectDuration;
    private bool isActivated;
    private UnityEngine.Coroutine slowMotionCoroutine;

    private void Start()
    {
        spawnerScript = UnityEngine.Object.FindAnyObjectByType<global::SpawnerScript>();
        enemyShooting = UnityEngine.Object.FindAnyObjectByType<global::EnemyShooting>();
        stats = UnityEngine.Object.FindAnyObjectByType<global::GameStats>();
    }

    private void Update()
    {
        if (isActivated) return;

        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
        {
            StartCoroutine(SlowMotion());
        }
    }

    System.Collections.IEnumerator SlowMotion()
    {
        yield return null;
        // Slow motion effect starts
        UnityEngine.Debug.Log("Effect started!");
        isActivated = true;

        // spawn time for obstacle increases
        spawnerScript.obstacleSpawnTime *= theWorld.multiplier;

        // Obsatcles move slow
        foreach (var obstacle in UnityEngine.Object.FindObjectsByType<global::SpawnerScript>(UnityEngine.FindObjectsSortMode.None))
        {
            spawnerScript.obstacleSpeed /= theWorld.multiplier;
        }

        var obstacles = UnityEngine.Object.FindObjectsByType<UnityEngine.Rigidbody2D>(UnityEngine.FindObjectsSortMode.None);
        foreach (var rb in obstacles)
        {
            if (rb.CompareTag("Obstacle"))
            {
                rb.linearVelocity = UnityEngine.Vector2.left * theWorld.obsatcleSpeed;
            }
        }

        // Projectiles move slow
        GameStats.instance.defaultProjectileSpeed = theWorld.projectileSpeed;

        foreach (var projectile in UnityEngine.Object.FindObjectsByType<global::EnemyShooting>(UnityEngine.FindObjectsSortMode.None))
        {
            projectile.projectileSpeed = projectile.projectileSpeed / theWorld.multiplier;
        }

        var projectiles = UnityEngine.Object.FindObjectsByType<UnityEngine.Rigidbody2D>(UnityEngine.FindObjectsSortMode.None);
        foreach (var rb in projectiles)
        {
            if (rb.CompareTag("Projectile"))
            {
                rb.linearVelocity = UnityEngine.Vector2.left * theWorld.projectileSpeed;
            }
        }

        // Slow motion effect ends
        yield return new UnityEngine.WaitForSeconds (effectDuration);
        UnityEngine.Debug.Log("Effect ended!");
        //isActivated = false;

        //if (isActivated == false)
        //{
        //    Destroy(gameObject);
        //}

        //spawnerScript.obstacleSpeed = stats.defaultObstacleSpeed;

        //enemyShooting.projectileSpeed = stats.defaultProjectileSpeed;

    }
}
