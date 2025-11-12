using Unity.Hierarchy;
using UnityEngine;

[CreateAssetMenu (fileName = "New Card", menuName = "Card/Minoin")]
public class Cards : ScriptableObject
{
    public string cardName;
    public Sprite cardSprite;

    public float obsatcleSpeed;
    public float projectileSpeed;

    public float minProjectileDelay;
    public float maxProjectileDelay;

    public float spawnTime;

    public float multiplierOrHalfing;

    public float cardTimer;
}
