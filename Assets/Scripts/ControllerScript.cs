using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ControllerScript : MonoBehaviour
{
    [Header("Check Player")]
    [SerializeField] public bool isPlayer;
    [SerializeField] public bool isEnemy;
    [Header("Component in this")]
    [SerializeField] GameManager gameManager;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] public Enemy targetOfPlayer;
    [SerializeField] public Player targetOfEnemy;
    [Header("State")]
    [SerializeField] public string currentState;
    [SerializeField] public bool isAttack;
    [Header("Collider With Skinned")]
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] MeshCollider meshCollider;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        isAttack = false;
        SetComponentStart();
        SetStateStart();
        if (GetComponent<Player>() != null)
        {
            isPlayer = true;
            isEnemy = false;
        }
        else if (GetComponent<Enemy>() != null)
        {
            isPlayer = false;
            isEnemy = true;
            targetOfEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        else Debug.LogWarning("ControllerScript: Start: without Player && Enemy");
    }
    void Update()
    {
        UpdateCollider();
        if (currentState != gameManager.meleeAttack)
        {
            doWalkingToTarget(isPlayer, isEnemy);
            doIdle();
        }
        doMeleeAttack(isPlayer, isEnemy);
    }
    //Do
    #region Do
    void doIdle()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    ChangeAnimationState(gameManager.idle);
                }
            }
        }

    }
    void doWalkingToTarget(bool isPlayer, bool isEnemy)
    {
        if (isPlayer && !isEnemy)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue))
                {
                    targetOfPlayer = hit.transform.GetComponent<Enemy>();
                    if (targetOfPlayer != null)
                    {
                        isAttack = true;
                        agent.destination = targetOfPlayer.transform.position;
                        agent.stoppingDistance = 1.5f;
                        if (Vector3.Distance(transform.position, targetOfPlayer.transform.position) >= agent.stoppingDistance)
                            ChangeAnimationState(gameManager.walking);
                    }
                    else
                    {
                        agent.stoppingDistance = 0f;
                        agent.destination = hit.point;
                        ChangeAnimationState(gameManager.walking);
                    }
                }
            }
        }
        else if(!isPlayer && isEnemy)
        {
            agent.stoppingDistance = 1.5f;
            if (isAttack == true && (Vector3.Distance(transform.position, targetOfEnemy.transform.position) >= agent.stoppingDistance))
            {
                agent.destination = targetOfEnemy.transform.position;
                ChangeAnimationState(gameManager.walking);
            }
        }
        else Debug.LogWarning("ControllerScript: doWalkingToTarget: isPlayer && isEnemy" + isPlayer + ":" + isEnemy);
    }
    void doMeleeAttack(bool isPlayer, bool isEnemy)
    {
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isAttack == true)
        {
            Vector3 dis = new Vector3();
            if (isPlayer && !isEnemy)
            {
                dis = targetOfPlayer.transform.position;
            }
            else if(!isPlayer && isEnemy)
            {
                dis = targetOfEnemy.transform.position;
            }
            else Debug.LogWarning("ControllerScript: doMeleeAttack: isPlayer && isEnemy" + isPlayer + ":" + isEnemy);
            transform.LookAt(dis);
            ChangeAnimationState(gameManager.meleeAttack);
        }
    }
    #endregion
    //Set Start
    #region Set Start
    void SetComponentStart()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }
    void SetStateStart()
    {
        animator.Play(gameManager.idle);
        currentState = gameManager.idle;
    }
    #endregion 
    void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(colliderMesh);
        meshCollider.sharedMesh = null;
        meshCollider.sharedMesh = colliderMesh;
    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;
        animator.Play(newState);
        currentState = newState;
    }
}
