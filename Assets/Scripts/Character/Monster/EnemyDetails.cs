using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetails : MonoBehaviour
{
    [Header("Class")]
    [SerializeField] private SAOMonsterStartingStat saoMonsterStartingStat;
    [Header("Details")]
    public int level;
    public Enum_DamageSource damageSource;
    [Space]
    [Header("Stats")]
    [Space]
    [Header("Combat Stat")]
    public int final_Life;
    public int final_Heal;
    public int final_MinDamage;
    public int final_MaxDamage;
    public int final_PhysicRes;
    public int final_MagicRes;
    public int final_AttackRating;
    public int final_Defense;
    public int final_AttackRange;
    public float final_AttackSpeed; // time to hit
    [Space]
    [Header("Current ")]
    public int currentLife;
    public int current_Life
    {
        get { return currentLife; }
        set
        {
            if (currentLife < 0) currentLife = 0;
            if (currentLife > final_Life) currentLife = final_Life;
        }
    }
    [Space]
    [Header("Exp")]
    public int final_exp;
    private void Start()
    {
        if (saoMonsterStartingStat == null) Debug.LogWarning(saoMonsterStartingStat);
        else
        {
            this.name = saoMonsterStartingStat.name;
            damageSource = saoMonsterStartingStat.damageSource;
            final_Life = UnityEngine.Random.Range(saoMonsterStartingStat.minLife, saoMonsterStartingStat.maxLife + 1);
            final_Heal = saoMonsterStartingStat.heal;
            final_MinDamage = saoMonsterStartingStat.minDamage;
            final_MaxDamage = saoMonsterStartingStat.maxDamage;
            final_PhysicRes = saoMonsterStartingStat.physicRes;
            final_MagicRes = saoMonsterStartingStat.magicRes;
            final_AttackRating = saoMonsterStartingStat.attackRating;
            final_Defense = saoMonsterStartingStat.defense;
            final_AttackRange = saoMonsterStartingStat.attackRange;
            final_AttackSpeed = saoMonsterStartingStat.attackSpeed;
            final_exp = saoMonsterStartingStat.exp;
            // current
            currentLife = final_Life;
        }
    }
    private void Update()
    {
        current_Life = currentLife;
    }
}
