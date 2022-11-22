using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
public enum AnimationStateName
{
    [EnumMember(Value = "Idle")] Idle,
    [EnumMember(Value = "Attack")] Attack,
    [EnumMember(Value = "Walking")] Walking,
    [EnumMember(Value = "Runing")] Runing,
    [EnumMember(Value = "Death")] Death,
}
public enum TypeCharacter
{
    Player = 1,
    Monster = 2,
}
public enum TypeWeapon
{
    Axe, // Riu
    Bow, // Cung
    Claw, // Mong vuot
    Javelin, // Lao
    Scepter, // Gay phep
    Spear, // Giao
    Sword, // Kiem
    Wand, // Dua phep
}
public class ControlAndAction : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] MeshCollider meshCollider;
    [SerializeField] Animator animator;
    [SerializeField] public AnimationStateName currentState;
    [SerializeField] AnimatorStateInfo animatorStateInfo;
    [SerializeField] public bool isAttacked;
    public void SetComponentWhenStart()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        //check null
        if (agent == null) Debug.LogWarning(agent);
        if (animator == null) Debug.LogWarning(animator);
        if (skinnedMeshRenderer == null) Debug.LogWarning(skinnedMeshRenderer);
        if (meshCollider == null) Debug.LogWarning(meshCollider);
    }
    public void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(colliderMesh);
        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = colliderMesh;
        if (meshCollider.sharedMesh == null) Debug.LogWarning(meshCollider.sharedMesh);
    }
    public void DoIdle()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    ChangeAnimationState(AnimationStateName.Idle);
                }
            }
        }
    }
    public void DoMeleeAttack(Component target)
    {
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isAttacked == true && target != null)
        { 
            transform.LookAt(target.transform.position);
            ChangeAnimationState(AnimationStateName.Attack);
            animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (animatorStateInfo.normalizedTime == 4 / 5)
            {
                //isSendDamage = true;
            }
        }
    }
    //public Component GetAnything(Monster targetForPlayer, Player targetForMonster)
    //{
    //    if (targetForPlayer != null) return targetForPlayer;
    //    if (targetForMonster != null) return targetForMonster;
    //    return null;
    //}
    public void DoDeath()
    {
        ChangeAnimationState(AnimationStateName.Death);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
    }
    public void SetMovementSpeed(int movementSpeed)
    {
        agent.speed = movementSpeed / 100f;
    }
    public void SetAttackRange(int attackRange)
    {
        agent.stoppingDistance = attackRange / 100f;
    }
    public void ChangeAnimationState(AnimationStateName newState)
    {
        if (currentState == newState) return;
        animator.Play(newState.ToString());
        currentState = newState;
    }
    public class Player : ControlAndAction
    {
        [SerializeField] public TypeCharacter type = TypeCharacter.Player;
        [SerializeField] public Monster target;
        
        public void DoMovementWithPointClick(int attackRange)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue))
                {
                    target = hit.transform.GetComponent<Monster>();
                    if (target != null)
                    {
                        SetAttackRange(attackRange);
                        isAttacked = true;
                        agent.destination = target.transform.position;
                        if (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance)
                            ChangeAnimationState(AnimationStateName.Walking);
                    }
                    else
                    {
                        agent.stoppingDistance = 0f;
                        agent.destination = hit.point;
                        ChangeAnimationState(AnimationStateName.Walking);
                    }
                }
            }
        }
        public void ClickTarget(Component target)
        {

        }
    }
    public class Monster : ControlAndAction
    {
        [SerializeField] public TypeCharacter type = TypeCharacter.Monster;
        [SerializeField] public Player target;
        public void DoWalkingToTarget(int attackRange) // Run to Target
        {
            SetAttackRange(attackRange);
            if (isAttacked == true && (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance))
            {
                agent.destination = target.transform.position;
                ChangeAnimationState(AnimationStateName.Walking);
            }
        }

    }
}
