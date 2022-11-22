using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Skill_1 : MonoBehaviour
{
    [SerializeField] float timer;
    public bool isCooldown;
    public bool isActivating;
    [SerializeField] SAOSkill_1 saoSkill_1;
    [SerializeField] PlayerDetails playerDetails;
    [SerializeField] GameObject effect;

    void Start()
    {
        effect.SetActive(false);
        timer = 0;
        isActivating = false;
        isCooldown = false;
    }
    void Update()
    {
        // Cooldown
        if (isCooldown == true)
        {
            timer += Time.deltaTime;
            if (timer >= saoSkill_1.cooldown)
            {
                isCooldown = false;
                timer = 0;
            }
            // Duration
            if (isActivating == true)
            {
                effect.SetActive(true);
                AddStatForPlayer();
            }
            if (timer >= saoSkill_1.duration)
            {
                isActivating = false;
            }
            if (isActivating == false)
            {
                effect.SetActive(false);
                playerDetails.damageBonusBySkill = 0;
            }
        }
    }
    void AddStatForPlayer()
    {
        playerDetails.damageBonusBySkill = saoSkill_1.bonusDamage;
    }

    public void ActiveSkill_1()
    {
        if (isCooldown == false && playerDetails.current_Mana >= saoSkill_1.manaCost)
        {
            playerDetails.current_Mana -= saoSkill_1.manaCost;
            isCooldown = true;
            isActivating = true;
        }
    }
}
