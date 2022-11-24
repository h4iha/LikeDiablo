using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SkillBool
{
    private List<Skill> skillList;
    public Action<Skill> onSkillSetLeft;
    public SkillBool (Action<Skill> onSkillSetLeft)
    {
        this.skillList = new List<Skill>();
        this.onSkillSetLeft = onSkillSetLeft;
        skillList.Add(new Skill() { type = TypeSkill.Passive, level = 1, skillActive = SkillActive.Bash });
        skillList.Add(new Skill() { type = TypeSkill.Passive, level = 1, skillPassive = SkillPassive.WeaponMastery });
    }
    public List<Skill> GetSkillList()
    {
        return skillList;
    }
    public void AddSkill(Skill skill)
    {
        skillList.Add(skill);
    }
    private void IncreaseSkillLevel(Skill skill)
    {
        foreach (Skill skillInList in skillList)
        {
            if (skillInList.type == skill.type)
            {
                if (skillInList.level < 20)
                {
                    skillInList.level++;
                }
            }
        }
    }
}
