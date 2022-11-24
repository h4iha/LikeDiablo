using UnityEngine;
[CreateAssetMenu(fileName = "SAOMonsterStartingStat", menuName = "Prefabs/SAO/Character/SAOMonsterStartingStat")]
public class SAOMonsterStartingStat : ScriptableObject
{
    [Header("Stat Combat")]
    public int minLife;
    public int maxLife;
    public int heal;
    public int minDamage;
    public int maxDamage;
    public int physicRes; // Reduces damage received from Physic sources
    public int magicRes; // Reduces damage received from Magic sources
    public int attackRange;
    public int attackSpeed;
    public int attackRating;
    public int defense;
    public int exp; // Exp for player
    [Space]
    public Enum_DamageSource damageSource;
}
