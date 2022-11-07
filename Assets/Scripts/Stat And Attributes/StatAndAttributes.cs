using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StatAndAttributes : MonoBehaviour
{
    [Header("Stat UI")]
    public float statUI_Max;
    public float statUI_Current;
    [Header("Stat Base")]
    public float statBase_totalBase;
    public float statBase_startingBase;
    public float statBase_EachLevel;
    [Header("Stat Bonus")]
    public float statBonus_total_Items;
    public float statBonus_total_Skill;
    public float FinalDamage(float damageWeapon,float attribute)
    {
        float finalDamage = damageWeapon * (attribute + 100) / 100;
        return finalDamage;
    }
    public float TotalDamage(float damageWeapon, float damageOtherEquipment, float statBonus, float enhancedDamage, float modifier)
    {
        float totalDamage = (damageWeapon + damageOtherEquipment) * (1 + statBonus + enhancedDamage) * modifier;
        return totalDamage;
    }
}
