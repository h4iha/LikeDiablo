using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class AttackScript : StateMachineBehaviour
{
    CharacterController characterController;
    GameObject go;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterController = animator.gameObject.GetComponent<CharacterController>();
        go = animator.gameObject;
        if (characterController != null && go != null)
        {
            characterController.currentState = StaticScripts.strAttack;
            characterController.isCanAttack = true;
            if (go.tag == StaticScripts.strPlayer)
            {
                
            }
            else if (go.tag == StaticScripts.strEnemy)
            {
                
            }
            else if (go.tag == StaticScripts.strNeutralCreep)
            {
                
            }
            else Debug.LogWarning(go.tag);
        }
        else
        {
            Debug.LogWarning(go);
            Debug.LogWarning(characterController);
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        characterController.currentState = StaticScripts.strIdle;
        if (go.tag == StaticScripts.strPlayer)
        {
            characterController.isCanAttack = false; // stop attack
            characterController.target.GetComponent<CharacterController>().isCanAttack = true;
        }
        else if (go.tag == StaticScripts.strEnemy)
        {

        }
        else if (go.tag == StaticScripts.strNeutralCreep)
        {

        }
        else Debug.LogWarning(go.tag);
    }
}
