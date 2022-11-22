using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;

public enum AnimationStatea
{
    [EnumMember(Value = "Idle")] Idle,
    [EnumMember(Value = "Attack")] Attack,
    [EnumMember(Value = "Walking")] Walking,
    [EnumMember(Value = "Death")] Death,
}


public class Character : MonoBehaviour
{
    [SerializeField] public GameObject target;
    [SerializeField] public AnimationStateName currentState;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] MeshCollider meshCollider;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorStateInfo asi;
    [SerializeField] public bool isCanAttack;
    void Start()
    {
        SetStart();
    }
    private void SetStart()
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
    public class PlayerC : Character
    {
        public void DoAttack()
        {
            Debug.Log("test");
        }
    }
    public void DoDeath()
    {
        ChangeAnimationState(AnimationStateName.Death);
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
    }
    public void DoMeleeAttack(Player player, Monster monster)
    {
        if (GetComponent<Player>() != null)
        {
            
        }
        if (target.GetComponent<Monster>() != null)
        {

        }
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isCanAttack == true && monster != null)
        {
            transform.LookAt(monster.transform.position);
            ChangeAnimationState(AnimationStateName.Attack);
            asi = animator.GetCurrentAnimatorStateInfo(0);
            if (asi.normalizedTime == 4 / 5)
            {
                if (CheckSendDamge(player.GetComponent<PlayerDetail>(), monster.GetComponent<MonsterDetail>()) == true)
                    SendDamage();
            }
        }
    }
    public int SendDamage()
    {

        return 1;
    }
    public bool CheckSendDamge(PlayerDetail playerDetail, MonsterDetail monsterDetail)
    {
        int chanceToHit = 0;
        if (GetComponent<PlayerDetail>() != null)
        {
            chanceToHit = playerDetail.current_AttackRating * playerDetail.current_Level * 100 /
                (playerDetail.current_AttackRating + monsterDetail.current_DefenseRating) * (playerDetail.current_Level + monsterDetail.current_Level);
        }
        if (target.GetComponent<MonsterDetail>() != null)
        {
            chanceToHit = monsterDetail.current_AttackRating * monsterDetail.current_Level * 100 /
                (monsterDetail.current_AttackRating + playerDetail.current_DefenseRating) * (monsterDetail.current_Level + playerDetail.current_Level);
        }
        if (chanceToHit > 95) chanceToHit = 95;
        if (chanceToHit < 5) chanceToHit = 5;
        if (UnityEngine.Random.Range(0, 100) < chanceToHit)
             return true;
        return false;
    }
    private void ChangeAnimationState(AnimationStateName newState)
    {
        if (currentState == newState) return;
        animator.Play(newState.ToString());
        currentState = newState;
    }
}
