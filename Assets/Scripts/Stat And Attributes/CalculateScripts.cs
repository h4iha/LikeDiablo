using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScripts : MonoBehaviour
{
    public static CalculateScripts instance;

    #region Chance To Do Function
    public int ChanceToHit(float attackRating, float defenseRating, int levelAttacker, int levelDefender)
    {
        int chanceUnlimited = (int)(200 * (attackRating / (attackRating + defenseRating)) * (levelAttacker / (levelDefender + levelDefender)));
        return chanceUnlimited;
    }
    public int ChanceToCrit(int chanceBonus)
    {
        int chanceUnlimited = (int) (1 / 24 + chanceBonus / 100) * 100;
        return chanceUnlimited;
    }
    public int ChanceToBlock(float blockByShield, float blockBySkills, float blockByItems, float dexterity, int characterLevel)
    {
        int chanceUnlimited = (int) ((blockByShield + blockBySkills + blockByItems) * (dexterity - 15) / (characterLevel * 2));
        return chanceUnlimited;
    }
    public int ChanceToDoubleRegen(float attribute, bool isLimit) //energy if Regenation Mana // vitality if Heal Life
    {
        if (attribute < 200)
            return (int)(attribute / 4);
        return (int)(100 - (10000 / attribute));
    }
    #endregion 
    #region Do Function
    public int DoLimited(int numberUnlimited, int minLimit, int maxLimit, int maxLimitBonus, int maxFinalLimit)
    {
        int numberLimited = numberUnlimited;
        maxLimit += maxLimitBonus;
        if (maxLimit > maxFinalLimit && maxFinalLimit > maxLimit)
            maxLimit = maxFinalLimit;
        if (numberLimited > maxLimit)
            numberLimited = maxLimit;
        if (numberLimited < minLimit)
            numberLimited = minLimit;
        return numberLimited;
    }
    public bool ChanceToDo(int chance)
    {
        int rd = UnityEngine.Random.Range(0, 100);
        if (rd < chance)
            return true;
        return false;
    }
    #endregion
}
