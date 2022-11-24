using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour,IPlayerTargeReachedHanele
{
    [Header("Check Character")]
    [SerializeField] public EnemyDetails enemyDetails;
    [SerializeField] public PlayerController target;
    [Space]
    [Header("Component in this")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorStateInfo asi;
    [Space]
    [Header("Damage Interactive")]
    [SerializeField] bool isSendDamage;
    [SerializeField] int damageInflicted;
    [SerializeField] public bool isApplyDamage;
    [SerializeField] public int damageTaken;
    [SerializeField] public int damageReduced;
    [Space]
    [Header("Anim")]
    [SerializeField] Enum_NameAnimationState nameAnimationState;
    [SerializeField] public string currentState;
    [SerializeField] public bool isCanAttack;
    [SerializeField] private string isDo;
    [Space]
    [Header("Collider With Skinned")]
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] MeshCollider meshCollider;

    private void Start()
    {
        enemyDetails = GetComponent<EnemyDetails>();
        //find player
        target = GameObject.FindGameObjectWithTag(Enum_CharacterType.Player.ToString()).gameObject.GetComponent<PlayerController>();
        //
        DoGetComponentStart();
        ChangeAnimationState(Enum_NameAnimationState.Idle.ToString());
    }
    private void Update()
    {
        UpdateCollider();
        if (enemyDetails.current_Life > 0)
        {
            if (currentState != Enum_NameAnimationState.Attack.ToString())
            {
                DoIdle();
                DoWalkingToTarget();
            }
            DoMeleeAttack();
            SendDamage();
            ApplyDamage();
        }
        else DoDeath();
    }
    private void DoGetComponentStart()
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

    #region Do Function
    private void DoIdle()
    {
        if (!agent) Debug.LogWarning("agent = null");
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    ChangeAnimationState(Enum_NameAnimationState.Idle.ToString());
                }
            }
        }
    }
    private void DoMeleeAttack()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isCanAttack == true)
        {
            transform.LookAt(target.transform.position);
            ChangeAnimationState(Enum_NameAnimationState.Attack.ToString());
            asi = animator.GetCurrentAnimatorStateInfo(0);
            if (asi.normalizedTime == 2 / 3)
            {
                isSendDamage = true;
            }
        }
    }
    //Walking
    private void DoWalkingToTarget() // Run to Target
    {
        agent.stoppingDistance = (float) (enemyDetails.final_AttackRange/100);
        if (isCanAttack == true && (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance))
        {
            agent.destination = target.transform.position;
            ChangeAnimationState(Enum_NameAnimationState.Walking.ToString());
        }
    }
    private void DoDeath()
    {
        ChangeAnimationState(Enum_NameAnimationState.Death.ToString());
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
    }
    #endregion
    public void SendDamage() //send to defender (target)
    {
        if (isSendDamage == true)
        {
            damageInflicted = UnityEngine.Random.Range(enemyDetails.final_MinDamage, enemyDetails.final_MaxDamage + 1);
            target.damageTaken = damageInflicted;
            target.isApplyDamage = true;
            isSendDamage = false;
            damageInflicted = 0;
        }
    }
    public void ApplyDamage() //receive from attacker
    {
        if (isApplyDamage == true)
        {
            enemyDetails.current_Life = enemyDetails.current_Life - (damageTaken - damageReduced);
            isApplyDamage = false;
            damageTaken = 0;
        }
    }
    public void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(colliderMesh);
        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = colliderMesh;
        if (meshCollider.sharedMesh == null) Debug.LogWarning(meshCollider.sharedMesh);
    }
    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
        if (currentState == null) Debug.LogWarning("currentState = null");
        if (newState == null) Debug.LogWarning("newState = null");
    }

    public void HandleReached(PlayerController controller)
    {
        Debug.Log("HandleReached");
        controller.DoAttack();
    }
}
