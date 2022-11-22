using System;
using UnityEngine;
[CreateAssetMenu(fileName = "SAOSkill_1", menuName = "Prefabs/SAO/Character/Class/Skill/SAOSkill_1")]
public class SAOSkill_1 : ScriptableObject
{
    public int cooldown;
    public int duration;
    public int manaCost;
    public int lifeCost;
    //Bonus Constant 
    public int bonusDamage;
    public int bonusAttackSpeed;
    public int bonusAttackRange;
    public int bonusDexterity;
    public int bonusStrength;
    public int bonusVitality;
    public int bonusEnergy;
    public int bonusAttackRating;
    public int bonusDefense;
    //Bonus By Percent Max Stat
    public float bonusDamageMax;
    public float bonusAttackSpeedMax;
    public float bonusAttackRangeMax;
    public float bonusDexterityMax;
    public float bonusStrengthMax;
    public float bonusVitalitygMax;
    public float bonusEnergygMax;
    public float bonusAttackRatingMax;
    public float bonusDefenseMax;
}
