using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetail : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] public int current_Level;
    [Space]
    [Header("Current Stat")]
    [SerializeField] public int current_Life;
    [SerializeField] public int current_AttackSpeed;
    [SerializeField] public int current_AttackRange;
    [SerializeField] public int current_MinDamage;
    [SerializeField] public int current_MaxDamage;
    [SerializeField] public int current_AttackRating;
    [SerializeField] public int current_DefenseRating;
    [SerializeField] public int current_MovementSpeed;
    [SerializeField] public int current_Heal;
    [SerializeField] public int current_DamageReduced;
    [SerializeField] public int current_MagicResistance;
    [SerializeField] public int curretn_ChanceToCrit;
    [Space]
    [Header("Max Stat")]
    [SerializeField] public int max_Life;
    [SerializeField] public int max_AttackSpeed;
    [SerializeField] public int max_AttackRange;
    [SerializeField] public int max_MinDamage;
    [SerializeField] public int max_MaxDamage;
    [SerializeField] public int max_AttackRating;
    [SerializeField] public int max_DefenseRating;
    [SerializeField] public int max_MovementSpeed;
    [SerializeField] public int max_Heal;
    [SerializeField] public int max_DamageReduced;
    [SerializeField] public int max_MagicResistance;
    [SerializeField] public int max_ChanceToCrit;
}
