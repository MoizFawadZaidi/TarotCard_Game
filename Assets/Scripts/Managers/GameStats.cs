using global::UnityEngine;

public class GameStats : UnityEngine.MonoBehaviour
{
    public static global::GameStats instance;

    public float defaultProjectileSpeed = 6f;
    public float defaultObstacleSpeed = 4f;

    public float slowProjectileSpeed;
    public float slowObstacleSpeed;

    private void Awake()
    {
        if (GameStats.instance == null)
        {
            GameStats.instance = this;
            //DontDestroyOnLoad(gameObject);

            //globalProjectileSpeed = defaultProjectileSpeed;
            //globalObstacleSpeed = defaultObstacleSpeed;
        }
    }
}
