using UnityEngine;
[CreateAssetMenu(fileName = "SAOEquipmentWeapon", menuName = "Prefabs/SAO/Equipment/SAOEquipmentWeapon")]
public class SAOEquipmentWeapon : ScriptableObject
{
    public string weaponName;
    [Space]
    public Enum_WeaponType type;
    public bool isTwoHand;
    public bool isMeleeRange;
    public Enum_DamageSource enum_DamageSource;
    [Space]
    [Header("Stat")]
    public int attackSpeed;
    public int attackRange;
    public int minDamage;
    public int maxDamage;
    [Space]
    public int minStrength;
    public int maxStrength;
    public int minDexterity;
    public int maxDexterity;
    [Space]
    [Header("Other")]
    public int durability;
    public int maxSockets;
    public int qualityLevel;
    public int requirementLevel;
}
