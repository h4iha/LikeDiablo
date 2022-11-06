using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{

    #region Strength
    public float BaseHitPointFunction(float _strength)
    {
        return StatsCalFunction(_strength, 20);
    }
    #endregion
    #region Dexterity
    public float BaseArmorFunction(float _agility)
    {
        return StatsCalFunction(_agility, 1 / 6);
    }
    public float BaseAttackSpeedFunction(float _agility)
    {
        return StatsCalFunction(_agility, 1);
    }
    #endregion
    #region Vitality
    public float BaseManaPointFunction(float _intelligent)
    {
        return StatsCalFunction(_intelligent, 12);
    }
    public float BaseManaPointRegenFunction(float _intelligent)
    {
        return StatsCalFunction(_intelligent, 0.05f);
    }
    #endregion
    #region Energy
    
    #endregion
    private float StatsCalFunction(float _attributes, float _cons)
    {
        return _attributes * _cons;
    }
}
