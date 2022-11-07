using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public float bonusDamageByStrength(float weaponDamage, float totalStrength) // Increases your damage by 1% of your weapon's damage each Strength
    {
        return weaponDamage * totalStrength * 0.01f;
    }
    public float bonusAttackRatingByDexterity(float totalDexterity) // Increases your Attack Rating by 5 each Dexterity // Accuracy
    {
        return totalDexterity * 5f;
    }
    public float bonusDefenseRatingByDexterity(float totalDexterity) // Increases your Defense Rating by 5 each Dexterity // Evasion
    {
        return totalDexterity * 0.25f;
    }

   
}
