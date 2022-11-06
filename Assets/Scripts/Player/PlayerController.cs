using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Component in this")]
    [SerializeField] GameManager gameManager;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Enemy enemy;
    public string currentState;
    public bool stopAttack;

    [Header("Stats")]
    #region Stats
    [SerializeField] private float _playerMaxHitPoint;
    [SerializeField] public float _playerCurrentHitPoint;
    #endregion 
    [Header("State Animation")]
    #region State Animation
    [SerializeField] Animator animator;
    #endregion 

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        SetStartComponent();
        SetStats();
    }
    void Update()
    {
        if (currentState != gameManager.meleeAttack)
        {
            doIdle();
            doWalkingToPoint();
        }
        doMeleeAttack();
    }
    #region Set Start Function
    void SetStartComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.Play(gameManager.idle);
        currentState = gameManager.idle;
        stopAttack = true;
    }
    void SetStats()
    {
        _playerMaxHitPoint = 10;
        _playerCurrentHitPoint = _playerMaxHitPoint;
    }
    #endregion
    #region Action Function
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
    void doWalkingToPoint()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit _hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, float.MaxValue))
            {
                enemy = _hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    stopAttack = false;
                    agent.destination = enemy.transform.position;
                    agent.stoppingDistance = 1.5f;
                    if (Vector3.Distance(transform.position, enemy.transform.position) >= agent.stoppingDistance)
                        ChangeAnimationState(gameManager.walking);
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    agent.destination = _hit.point;
                    ChangeAnimationState(gameManager.walking);
                }
            }
        }
    }
    void doMeleeAttack()
    {
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && stopAttack == false)
        {
            transform.LookAt(enemy.transform.position);
            ChangeAnimationState(gameManager.meleeAttack);
        }
    }
    #endregion
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
            return;
        animator.Play(newState);
        currentState = newState;
    }
}
