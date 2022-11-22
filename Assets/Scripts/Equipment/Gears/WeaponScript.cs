using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponScript : MonoBehaviour
{
    public SAOEquipmentWeapon saoEquipmentWeapon;
    [Space]
    public Item item;
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
    public int strength;
    public int dexterity;
    public int amount;
    public ItemType type;
    private void Start()
    {
        item = new Item();
        item.amount = 1;
        item.type = ItemType.Weapon;
        amount = item.amount;
        type = item.type;
        this.name = saoEquipmentWeapon.name;
        isMeleeRange = saoEquipmentWeapon.isMeleeRange;
        isTwoHand = saoEquipmentWeapon.isTwoHand;
        enum_DamageSource = saoEquipmentWeapon.enum_DamageSource;
        attackSpeed = saoEquipmentWeapon.attackSpeed;
        attackRange = saoEquipmentWeapon.attackRange;
        minDamage = saoEquipmentWeapon.minDamage;
        maxDamage = saoEquipmentWeapon.maxDamage;
        strength = UnityEngine.Random.Range(saoEquipmentWeapon.minStrength, saoEquipmentWeapon.maxStrength + 1);
        strength = UnityEngine.Random.Range(saoEquipmentWeapon.minDexterity, saoEquipmentWeapon.maxDexterity + 1);
    }
}
