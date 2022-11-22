using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusByEquipments : MonoBehaviour
{
    [Header("Gears")]
    [SerializeField] private GameObject parent;
    [SerializeField] private WeaponScript weapon;
    [SerializeField] private ShieldScript shield;
    [Space]
    [Header("Clothes")]
    [SerializeField] private HelmScript helm;
    [SerializeField] private ArmorScript armor;
    [SerializeField] private GlovesScript gloves;
    [SerializeField] private BeltScript belt;
    [SerializeField] private BootsScript boots;
    [Space]
    [Header("Jewels")]
    [SerializeField] private NecklaceScript necklace;
    [SerializeField] private RingScript ringL;
    [SerializeField] private RingScript ringR;
    [Space]
    [Header("Point Stat")]
    public int total_Strength;
    public int total_Dexterity;
    public int total_Vitality;
    public int total_Energy;
    [Space]
    [Header("Combat Stat")]
    public int total_Life;
    public int total_Mana;
    public int total_MinDamage;
    public int total_MaxDamage;
    public int total_PhysicRes;
    public int total_MagicRes;
    [Space]
    [Header("Accuracy and Attack Speed")]
    public int total_AttackRating;
    public int total_Defense;
    public int total_AttackSpeed;
    void Start()
    {
        weapon = parent.GetComponentInChildren<WeaponScript>();
        // Point Stats
        total_Strength = 0;
        total_Dexterity = 0;
        total_Vitality = 0;
        total_Energy = 0;
        // Combat Stat
        total_Life = 0;
        total_Mana = 0;
        total_MinDamage = 0;
        total_MaxDamage = 0;
        total_PhysicRes = 0;
        total_MagicRes = 0;
        // accuracy and attack speed
        total_AttackSpeed = 0;
        total_AttackRating = 0;
        total_Defense = 0;
    }
    void Update()
    {
        weapon = parent.GetComponentInChildren<WeaponScript>();
        // Point Stats
        total_Strength = weapon.strength + 0;
        total_Dexterity = weapon.dexterity + 0;
        total_Vitality = 0;
        total_Energy = 0;
        // Combat Stat
        total_Life = 0;
        total_Mana = 0;
        total_MinDamage = 0;
        total_MaxDamage = 0;
        total_PhysicRes = 0;
        total_MagicRes = 0;
        // accuracy and attack speed
        total_AttackSpeed = weapon.attackSpeed + 0;
        total_AttackRating = 0;
        total_Defense = 0;

    }
}
