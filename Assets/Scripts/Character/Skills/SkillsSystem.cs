using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsSystem : MonoBehaviour
{
    public Skill_1 skill_1;
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
            skill_1.ActiveSkill_1();
            activeSkill = false;
        }
    }
}
