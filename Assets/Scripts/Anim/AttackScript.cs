using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class AttackScript : StateMachineBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponentInParent<Controller>();
        if (controller != null)
        {
            player = animator.GetComponentInParent<Player>();
            enemy = animator.GetComponentInParent<Enemy>();
            if (player != null)
            {
                controller.isAttack = true;
                controller.currentState = StaticScripts.attack;
            }
            else if (enemy != null)
            {
                controller.currentState = StaticScripts.attack;
            }
            else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: player = null && enemy = null");
        }
        else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: controllerScript = null");
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player != null)
        {
            controller.isAttack = false;
            controller.currentState = StaticScripts.idle;
            controller.targetOfPlayer.GetComponent<Controller>().isAttack = true;
        }
        else if (enemy != null)
        {
            controller.currentState = StaticScripts.idle;
            //enemy.stopAttack = true;
            //enemy.currentState = TypeSript.idle;
        }
        else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: player = null && enemy = null");
    }
}
