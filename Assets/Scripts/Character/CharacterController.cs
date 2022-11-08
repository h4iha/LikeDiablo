using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Resources;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class CharacterController : MonoBehaviour
{
    [Header("Check Character")]
    [SerializeField] public string typeCharacter;
    [SerializeField] public GameObject target;
    [Space]
    [Header("Component in this")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorStateInfo asi;
    [Space]
    [Header("Damage Interactive")]
    [SerializeField] bool isSendDamage;
    [SerializeField] bool isApplyDamage;
    [SerializeField] int damageInflicted;
    [SerializeField] int damageTaken;
    [SerializeField] int damageReduced;
    [Space]
    [Header("Anim")]
    [SerializeField] public string currentState;
    [SerializeField] public bool isCanAttack;
    [SerializeField] private string isDo;
    [Space]
    [Header("Collider With Skinned")]
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] MeshCollider meshCollider;
    [Space]
    [SerializeField] int currenthp;

    private void Start()
    {
        currenthp = 20;
        damageInflicted = 10;
        damageReduced = 5;
        DoGetComponentStart();
        ChangeAnimationState(StaticScripts.strIdle);
    }
    private void Update()
    {
        UpdateCollider();
        if (currenthp > 0)
        {
            if (currentState != StaticScripts.strAttack)
            {
                DoIdle();

                if (tag == StaticScripts.strPlayer)
                {
                    DoWalkingPointToClick();
                }
                else if (tag == StaticScripts.strEnemy)
                {
                    target = GameObject.FindGameObjectWithTag(StaticScripts.strPlayer);
                    DoWalkingToTarget(target);
                }
                else if (tag == StaticScripts.strNeutralCreep)
                {
                    target = GameObject.FindGameObjectWithTag(StaticScripts.strPlayer);
                    DoWalkingToTarget(target);
                }
                else Debug.Log(tag);
            }
            DoMeleeAttack();
            SendDamage();
            ApplyDamage();
        }
        else ChangeAnimationState(StaticScripts.strDeath);
    }
    public void DoGetComponentStart()
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
    public void DoIdle()
    {
        if (!agent) Debug.LogWarning("agent = null");
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    ChangeAnimationState(StaticScripts.strIdle);
                }
            }
        }
    }
    public void DoMeleeAttack()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isCanAttack == true && target.GetComponent<CharacterController>().currenthp > 0)
        {
            transform.LookAt(target.transform.position);
            ChangeAnimationState(StaticScripts.strAttack);
            asi = animator.GetCurrentAnimatorStateInfo(0);
            if (asi.normalizedTime == 2 / 3)
            {
                isSendDamage = true;
            }
            
        }
    }
    //Walking
    public void DoWalkingPointToClick() // Player with Right Click
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue))
            {
                target = hit.transform.gameObject;
                if (target.tag == "Enemy" || target.tag == "NeutralCreep" || target.tag == "NPC")
                {
                    isCanAttack = (target.tag != "NPC") ? true : false;
                    agent.destination = target.transform.position;
                    agent.stoppingDistance = 1.5f;
                    if (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance)
                        ChangeAnimationState(StaticScripts.strWalking);
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    agent.destination = hit.point;
                    ChangeAnimationState(StaticScripts.strWalking);
                }
            }
        }
    }
    public void DoWalkingToTarget(GameObject target) // Run to Target
    {
        agent.stoppingDistance = 1.5f;
        if (isCanAttack == true && (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance))
        {
            agent.destination = target.transform.position;
            ChangeAnimationState(StaticScripts.strWalking);
        }
    }
    #endregion
    public void SendDamage() //send to defender (target)
    {
        if (isSendDamage == true)
        {
            CharacterController targetCC = target.GetComponent<CharacterController>();
            targetCC.damageTaken = damageInflicted - targetCC.damageReduced;
            targetCC.isApplyDamage = true;
            isSendDamage = false;
        }
    }
    public void ApplyDamage() //receive from attacker
    {
        if(isApplyDamage == true)
        {
            currenthp = currenthp - damageTaken;
            Debug.Log("isApplyDamage true: " + isApplyDamage);
            isApplyDamage = false;
            Debug.Log("isApplyDamage false 1: " + isApplyDamage);
        }
        Debug.Log("isApplyDamage false 2: " + isApplyDamage);
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
        if (currentState == null) Debug.LogWarning("currentState = null");
        if (newState == null) Debug.LogWarning("newState = null");

        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }
}
