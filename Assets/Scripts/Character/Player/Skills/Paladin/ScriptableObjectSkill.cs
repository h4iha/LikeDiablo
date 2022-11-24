using System;
using UnityEngine;
[CreateAssetMenu(fileName = "Skill", menuName = "Prefabs/SAO/Character/Player/Skill")]

public class ScriptableObjectSkill : ScriptableObject
{
    [SerializeField] public int Cost;
}
