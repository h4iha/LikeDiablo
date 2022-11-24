using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public PlayerController controller;
    [SerializeField] public PlayerDetail detail;
    [SerializeField] public SkillSystem skillSystem;
    [SerializeField] public UI_Inventory ui_Inventory;
    [SerializeField] public Inventory inventory;
    [Header("Skill")]
    [SerializeField] public string leftSkill;
    [SerializeField] private bool isLeftClicked = false;
    [SerializeField] public GameObject target;
    private void Awake()
    {
        GiveComponentWhenStart();
        controller.onItemPickup = HandleItemPickup;
        inventory = new Inventory(HandleUseItem);
        Debug.Log(inventory);

        ui_Inventory.SetInventory(inventory);
        Debug.LogWarning(inventory.GetItemList().Count);
    }

    private void HandleItemPickup(Item obj)
    {
       Debug.Log(obj.type);
        inventory.PickUpItem(obj);
    }

    private void Start()
    {
        controller.ChangeAnimationState(Enum_NameAnimationState.Idle.ToString());
        //leftSkill = "1";
        //skillSystem.leftSkill = leftSkill;
    }
    void GiveComponentWhenStart()
    {
        detail = GetComponent<PlayerDetail>();
        skillSystem = GetComponent<SkillSystem>();
        controller = GetComponent<PlayerController>();
        controller.GiveComponentWhenStart();

    }
    private void Update()
    {
        controller.UpdateCollider();
        if (detail.current_Life > 0)
        {
            if (controller.currentState != Enum_NameAnimationState.Attack.ToString())
            {
                controller.DoIdle();
            }
            if (Input.GetMouseButtonDown(0))
            {
                isLeftClicked = true;
                controller.DoWhenLeftClick(detail.final_AttackRange);
            }
            if (isLeftClicked == true)
            {
                controller.DoMeleeAttack(target);
                isLeftClicked = false;
            }

        }
        else controller.DoDeath();
    }
    private void HandleUseItem(Item item)
    {
        Debug.Log(item.type);
        if (item.type == ItemType.Potion)
        {
            detail.current_Life += 5;
        }
    }
}
