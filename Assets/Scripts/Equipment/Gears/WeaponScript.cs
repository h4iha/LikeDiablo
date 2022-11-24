using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponScript : MonoBehaviour,IPlayerTargeReachedHanele
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

    public void HandleReached(PlayerController controller)
    {
        Debug.Log("HandleReached");
        controller.DoPickup(item);
        DestroyThis();
    }

    private void Start()
    {
        item = new Item();
        item.type = type;
        item.amount = 1;
        amount = item.amount;
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
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
