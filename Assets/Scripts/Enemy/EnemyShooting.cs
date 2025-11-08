using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private GameObject[] projectilePrefabs;

    public Transform projectilePos;

    ObjectPooling objectPool;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectPool = FindAnyObjectByType<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
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
    }
}
