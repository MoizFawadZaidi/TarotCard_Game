using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats instance;

    public float defaultProjectileSpeed = 6f;
    public float defaultObstacleSpeed = 4f;

    public float slowProjectileSpeed;
    public float slowObstacleSpeed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //globalProjectileSpeed = defaultProjectileSpeed;
            //globalObstacleSpeed = defaultObstacleSpeed;
        }
    }
}
