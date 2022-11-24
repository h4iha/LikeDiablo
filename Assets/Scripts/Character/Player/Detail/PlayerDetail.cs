using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerDetail : MonoBehaviour
{
    [Header("Class")]
    [SerializeField] private SAOClassStartingStat saoClassStartingStat;
    [Header("Details")]
    [Space]
    public string characterName;
    public int current_Level;
    public int max_Level;
    [Space]
    [Header("Stats")]
    [Space]
    [Header("Point Stat")]
    public int final_Strength;
    public int final_Dexterity;
    public int final_Vitality;
    public int final_Energy;
    [Space]
    [Header("Combat Stat")]
    public int final_Life;
    public int final_Mana;
    public int final_MinDamage;
    public int final_MaxDamage;
    public int final_PhysicRes;
    public int final_MagicRes;
    public int final_AttackRating;
    public int final_DefenseRating;
    public int final_AttackRange;
    public int final_AttackSpeed;
    [Space]
    [Header("Current ")]
    public int current_Life;
    public int current_Mana;
    [Space]
    [Header("Exp")]
    public int max_Exp;
    public int current_Exp;
    public int total_ExpGained;
    public int required_Exp;
    [Space]
    [Header("Weapon")]
    public int current_Weapon;
    public WeaponScript equipment;
    public GameObject weapon1;
    public GameObject weapon2;

    [Space]
    [Header(("Bonus Stats"))]
    [SerializeField] public int damageBonusBySkill;
    private void Start()
    {
        current_Life = 10;
        //Get Component
        equipment = weapon1.GetComponent<WeaponScript>();

        final_AttackRange = equipment.attackRange;
        // Level
        max_Level = 100;
        current_Level = 1;
        // Experience
        current_Exp = 0;
        Cal_MaxLevel();
        LevelFunction();
        // Weapon
        weapon1.SetActive(true);
        weapon2.SetActive(false);
        //
        StatFunction();
        current_Life = final_Life;
        current_Mana = final_Mana;
    }
    private void Update()
    {
        if (current_Life <= 0) current_Life = 0;
        if (current_Life > final_Life) current_Life = final_Life;
        if (current_Mana <= 0) current_Mana = 0;
        if (current_Mana > final_Mana) current_Mana = final_Mana;
        LevelFunction();
        WeaponChangeManually();
        StatFunction();
    }
    private void WeaponChangeManually()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipment = weapon1.GetComponent<WeaponScript>();
            weapon1.SetActive(true);
            weapon2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipment = weapon2.GetComponent<WeaponScript>();
            weapon1.SetActive(false);
            weapon2.SetActive(true);
        }
    }
    //
    #region Exp and Level
    private void LevelFunction()
    {
        // Max exp and level
        if (current_Exp >= max_Exp)
        {
            current_Level = max_Level;
            current_Exp = max_Exp;
            total_ExpGained = max_Exp;
        }
        // can increase level and exp
        else
        {
            UpLevel();
            Cal_ExpRequired();
            TotalExpGainedUpdate();
        }
    }
    private void Cal_MaxLevel()
    {
        for (int i = 1; i < max_Level; i++)
        {
            max_Exp += (i - 1) * i * 500;
        }
    }
    private void UpLevel()
    {
        if (current_Exp >= required_Exp)
        {
            current_Exp -= required_Exp;
            current_Level++;
        }
    }
    private void TotalExpGainedUpdate()
    {
        int total = 0;
        for (int i = 1; i < current_Level; i++)
        {
            total += (i - 1) * i * 500;
        }
        total_ExpGained = total + current_Exp;
    }
    private void Cal_ExpRequired()
    {
        required_Exp = (current_Level - 1) * current_Level * 500;
    }
    #endregion
    //

    #region Stats
    private void StatFunction()
    {
        final_AttackRange = equipment.attackRange;
        // Point Stat
        final_Strength = Cal_PointStat(saoClassStartingStat.strength, 0, 0);
        final_Dexterity = Cal_PointStat(saoClassStartingStat.dexteriry, 0, 0);
        final_Vitality = Cal_PointStat(saoClassStartingStat.vitality, 0, 0);
        final_Energy = Cal_PointStat(saoClassStartingStat.energy, 0, 0);
        // Life and Mana
        final_Life = Cal_LifeOrMana(saoClassStartingStat.life, current_Level, saoClassStartingStat.lifeByLevel, final_Strength, saoClassStartingStat.lifeByPoint, 0, 0);
        final_Mana = Cal_LifeOrMana(saoClassStartingStat.mana, current_Level, saoClassStartingStat.manaByLevel, final_Strength, saoClassStartingStat.manaByPoint, 0, 0);
        // Damage
        final_MinDamage = Cal_Damage(equipment.minDamage, final_Strength, 0, damageBonusBySkill);
        final_MaxDamage = Cal_Damage(equipment.maxDamage, final_Strength, 0, damageBonusBySkill);
        // Other
        final_AttackRange = equipment.attackRange;
        final_AttackSpeed = 150 + equipment.attackSpeed;
        final_AttackRating = Cal_AttackRating(final_Dexterity, 0, 0);
        final_DefenseRating = Cal_Defense(final_Dexterity, 0, 0);
    }
    // Point Stat
    private int Cal_PointStat(int startingStat, int bonusByEquipments, int bonusBySkills)
    {
        return startingStat + bonusByEquipments + bonusBySkills;
    }
    private int Cal_LifeOrMana(int startingStat, int level, float bonusByLevel, int finalPointStat, float bonusByPoint,  int bonusByEquipments, int bonusBySkills)
    {
        return startingStat + (int) (level * bonusByLevel) + (int) (finalPointStat * bonusByPoint) + bonusByEquipments + bonusBySkills;
    }
    private int Cal_Damage(int damageWeapon, int finalPointStat, int bonusByEquipments, int bonusBySkills)
    {
        return damageWeapon + (int)(damageWeapon * ((float) finalPointStat / 100)) + bonusByEquipments + bonusBySkills;
    }
    private int Cal_Defense(int finalDexterity, int bonusByEquipments, int bonusBySkills)
    {
        return finalDexterity / 4 + bonusByEquipments + bonusBySkills;
    }
    private int Cal_AttackRating(int finalDexterity, int bonusByEquipments, int bonusBySkills)
    {
        return finalDexterity / 2 + bonusByEquipments + bonusBySkills;
    }
    #endregion
}
