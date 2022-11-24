using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    //public Skill skill;
    public string leftSkill;
    public string rightSkill;
    public bool activeSkill;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftSkill == "1" && activeSkill == true)
        {
            //skill.ActiveSkill_1();
            activeSkill = false;
        }
    }
}
