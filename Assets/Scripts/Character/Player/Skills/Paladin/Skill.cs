using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public enum TypeSkill
{
    Passive = 0,
    ActiveAttack = 1,
    ActiveWithDuration = 2,
}

public enum TypeStat
{
    Life = 0,
    Mana = 1,
    Damage = 2,
    AttackRating = 3,
    DefenseRating = 4,
}
public enum SkillPassive
{
    WeaponMastery = 0,
    IronSkin = 1,
}
public enum SkillActive
{
    Bash = 0,
    DoubleWing = 1,
}
public class Skill
{
    public TypeSkill type;
    public int level;
    public bool IsPassive()
    {
        return type == TypeSkill.Passive;
    }
    public SkillPassive skillPassive;
    public SkillActive skillActive;
}
//public class Skill1 : MonoBehaviour
//{
//    [SerializeField] float timer;
//    public bool isCooldown;
//    public bool isActivating;
//    [SerializeField] SAOSkill_1 saoSkill_1;
//    [SerializeField] PlayerDetail playerDetail;
//    [SerializeField] GameObject effect;

//    void Start()
//    {
//        effect.SetActive(false);
//        timer = 0;
//        isActivating = false;
//        isCooldown = false;
//    }
//    void Update()
//    {
//        // Cooldown
//        if (isCooldown == true)
//        {
//            timer += Time.deltaTime;
//            if (timer >= saoSkill_1.cooldown)
//            {
//                isCooldown = false;
//                timer = 0;
//            }
//            // Duration
//            if (isActivating == true)
//            {
//                effect.SetActive(true);
//                AddStatForPlayer();
//            }
//            if (timer >= saoSkill_1.duration)
//            {
//                isActivating = false;
//            }
//            if (isActivating == false)
//            {
//                effect.SetActive(false);
//                playerDetail.damageBonusBySkill = 0;
//            }
//        }
//    }
//    void AddStatForPlayer()
//    {
//        playerDetail.damageBonusBySkill = saoSkill_1.bonusDamage;
//    }

//    public void ActiveSkill_1()
//    {
//        if (isCooldown == false && playerDetail.current_Mana >= saoSkill_1.manaCost)
//        {
//            playerDetail.current_Mana -= saoSkill_1.manaCost;
//            isCooldown = true;
//            isActivating = true;
//        }
//    }
//}
