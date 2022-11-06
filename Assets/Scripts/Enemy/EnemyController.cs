using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _playerGO;
    [SerializeField] private Animator _animator;
    [SerializeField] NavMeshAgent agent;
    void Start()
    {
        _playerGO = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FindPlayerWithVision()
    {
    }
    void FollowPlayer()
    {
        agent.SetDestination(_playerGO.transform.position);
    }
    void EnemyDead()
    {
        
    }
}
