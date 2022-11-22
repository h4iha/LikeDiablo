using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] public ControlAndAction.Monster character;
    [SerializeField] public Detail.Monster detail;
    void Start()
    {
        character = GetComponent<ControlAndAction.Monster>();
        character.DoIdle();
    }

    // Update is called once per frame
    void Update()
    {
        if (detail.currentLife > 0)
        {
            character.SetMovementSpeed(detail.currentLife);
            character.UpdateCollider();
            if (character.currentState != AnimationStateName.Attack)
            {
                character.DoIdle();
                character.DoWalkingToTarget(detail.currentAttackRange);
            }
            character.DoMeleeAttack(character.target);
        }
        else character.DoDeath();
    }
}
