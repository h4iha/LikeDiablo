using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class IsAnimMeleeAttack : StateMachineBehaviour
{
    [SerializeField] ControllerScript controllerScript;
    [SerializeField] GameManager gameManager;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            controllerScript = animator.GetComponentInParent<ControllerScript>();
            if (controllerScript != null)
            {
                player = animator.GetComponentInParent<Player>();
                enemy = animator.GetComponentInParent<Enemy>();
                if (player != null )
                {
                    controllerScript.isAttack = true;
                    controllerScript.currentState = gameManager.meleeAttack;
                }
                else if (enemy != null)
                {
                    controllerScript.currentState = gameManager.meleeAttack;
                }
                else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: player = null && enemy = null");
            }
            else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: controllerScript = null");
        }
        else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: gameManager = null");
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player != null)
        {
            controllerScript.isAttack = false;
            controllerScript.currentState = gameManager.idle;
            controllerScript.targetOfPlayer.GetComponent<ControllerScript>().isAttack = true;
        }
        else if (enemy != null)
        {
            controllerScript.currentState = gameManager.idle;
            Debug.Log("exit");
            //enemy.stopAttack = true;
            //enemy.currentState = animManager.idle;
        }
        else Debug.LogWarning("IsAnimMeleeAttack: OnStateEnter: player = null && enemy = null");
    }
}
