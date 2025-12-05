using Unity.Hierarchy;
using global::UnityEngine;

[UnityEngine.CreateAssetMenu (fileName = "New Card", menuName = "Card/Minoin")]
public class Cards : UnityEngine.ScriptableObject
{
    public string cardName;
    public UnityEngine.Sprite cardSprite;

    public float obsatcleSpeed;
    public float projectileSpeed;

    public float minProjectileDelay;
    public float maxProjectileDelay;

    public float spawnTime;

    public float multiplier;

    public float noOfObstaclesPassed;

    public float cardTimer;
}
