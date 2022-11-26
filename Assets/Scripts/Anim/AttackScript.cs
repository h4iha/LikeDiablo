using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : StateMachineBehaviour
{
    PlayerController playerController;
    EnemyController enemyController;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerController = animator.gameObject.GetComponent<PlayerController>();
        enemyController = animator.gameObject.GetComponent<EnemyController>();
        if (playerController != null)
        {
            playerController.currentState = Enum_NameAnimationState.Attack.ToString();
            playerController.isCanAttack = true;
        }
        else if (enemyController != null)
        {
            enemyController.currentState = Enum_NameAnimationState.Attack.ToString();
            enemyController.isCanAttack = true;
        }
        else
        {
            Debug.LogWarning(playerController);
            Debug.LogWarning(enemyController);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerController != null)
        {
            playerController.currentState = Enum_NameAnimationState.Idle.ToString();
            playerController.isCanAttack = false; // stop attack
            //TODO: bi xoa target
           /// if(playerController.target != null) playerController.target.isCanAttack = true;
        }
        else if (enemyController != null)
        {
            enemyController.currentState = Enum_NameAnimationState.Idle.ToString();
            if (enemyController.target.gameObject.GetComponent<PlayerDetail>().current_Life <= 0)
                enemyController.isCanAttack = false;
            // enemyController.isCanAttack = false; // stop attack
        }
        else
        {
            Debug.LogWarning(playerController);
            Debug.LogWarning(enemyController);
        }
    }
}
