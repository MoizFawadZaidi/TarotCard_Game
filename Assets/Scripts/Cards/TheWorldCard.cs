using UnityEngine;

public class TheWorldCard : MonoBehaviour
{

    public Cards theWorld;
    SpawnerScript objectSpawner;
    EnemyShooting enemyShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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
            enemyShooting.projectileSpeed = theWorld.projectileSpeed;
        }
    }
}
