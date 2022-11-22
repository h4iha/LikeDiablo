using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    [SerializeField] public ControlAndAction.Player character;
    [SerializeField] public Detail.Player playerDetail;
    [SerializeField] public Monster target;
    void Start()
    {
        character = GetComponent<ControlAndAction.Player>();
        character.DoIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetail.currentLife > 0)
        {
            character.UpdateCollider();
            if (character.currentState != AnimationStateName.Attack)
            {
                character.DoIdle();
                character.DoMovementWithPointClick(playerDetail.currentAttackRange);
            }
            character.DoMeleeAttack(character.target);
        }
        else character.DoDeath();
    }
}
