using UnityEngine;

[CreateAssetMenu(menuName = "Enemy stats values")]
public class EnemyStats : ScriptableObject
{
    #region Variables
    [Header("Health values")]
    [Tooltip("Current health.")]
    public int health;

    [Header("Damage values")]
    [Tooltip("Defines the damage dealt.")]
    public int damage;
    public float range;
    public float attackCooldown;
    #endregion  
}