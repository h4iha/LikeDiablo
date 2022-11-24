using System;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillPassive", menuName = "Prefabs/ScriptableObject/Character/Player/Skill/SkillPassive")]

public class ScriptableObjectSkillPassive : ScriptableObject
{
    [SerializeField]
    public int numberStats;
    public TypeStat[] typeStats;
    public int[] statBonuses;
}
