using System;
using UnityEngine;
using UnityEngine.AI;


public interface IPlayerTargeReachedHanele
{
    void HandleReached(PlayerController controller);
}

public enum MoveState
{
    Move,
    Attack,
    Pickup,
    None
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject enemyDetail;
    [SerializeField] public WeaponScript weaponTarget;
    [Space]
    [Header("Component in this")]
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorStateInfo asi;
    [Space]
    [Header("Anim")]
    [SerializeField] public string currentState;
    [SerializeField] public bool isCanAttack;
    [Space]
    [Header("Collider With Skinned")]
    [SerializeField] SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] MeshCollider meshCollider;
    [Space]
    [Header("Damage Interactive")]
    [SerializeField] int damageInflicted;
    [SerializeField] public bool isApplyDamage;
    [SerializeField] public int damageTaken;
    [SerializeField] public int damageReduced;

    public Action<Item> onItemPickup;


    private IPlayerTargeReachedHanele playerTargeReachedHanele;
    private bool isCheckForReached;
    //[SerializeField] public Skill_1 RightSkill;

    public void GiveComponentWhenStart()
    {
        enemyDetail = GameObject.Find("Enemy Detail Bar");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    #region Do Function
    public void DoIdle()
    {
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
    public void DoMeleeAttack(GameObject target)
    {
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isCanAttack == true && target.GetComponent<EnemyController>() != null)
        {
            transform.LookAt(target.transform.position);
            ChangeAnimationState(Enum_NameAnimationState.Attack.ToString());
            asi = animator.GetCurrentAnimatorStateInfo(0);
            if (asi.normalizedTime == 2 / 3)
            {
                //isSendDamage = true;
            }
        }
    }

    private void Update()
    {
        if (isCheckForReached)
        {
            if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance)
            {
                isCheckForReached = false;
                if (playerTargeReachedHanele != null)
                {
                    playerTargeReachedHanele.HandleReached(this);
                }
            }
        }
    }

    //Walking
    public void DoWhenLeftClick(int attackRange) // Player with Right Click
    {
        RaycastHit hit;
        #region Version Cu
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue))
        //{
        //    //weaponTarget = hit.transform.GetComponent<WeaponScript>();
        //    if (hit.transform.GetComponent<EnemyController>() != null)
        //    {
        //        DoMeleeAttack(target);
        //        target = hit.transform.gameObject;
        //        isCanAttack = true;
        //        agent.destination = target.transform.position;
        //        agent.stoppingDistance = attackRange / 100f;
        //        if (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance)
        //            ChangeAnimationState(Enum_NameAnimationState.Walking.ToString());
        //    }
        //    else if (hit.transform.GetComponent<WeaponScript>() != null)
        //    {
        //        target = hit.transform.gameObject;
        //    }
        //    else
        //    {
        //        agent.stoppingDistance = 0f;
        //        agent.destination = hit.point;
        //        ChangeAnimationState(Enum_NameAnimationState.Walking.ToString());
        //    }
        //}
        #endregion
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue))
        {

            Debug.Log("ray cast hit somthing: "+hit.transform.gameObject.name);
            playerTargeReachedHanele = hit.transform.GetComponent<IPlayerTargeReachedHanele>();
            float stopingDistance = 0;
            Vector3 destination = hit.point;
            if(playerTargeReachedHanele != null)
            {
                stopingDistance = attackRange / 100;
                destination = hit.transform.position;
            }

            agent.stoppingDistance = stopingDistance;
            agent.destination = destination;

            isCheckForReached = true;
            // danh enemy

        }
    }

    public void DoAttack()
    {
        Debug.Log("DO Attack");
    }
    public void DoPickup(Item item)
    {
        Debug.Log("do pickup");
        onItemPickup?.Invoke(item);
    }

    public void DoDeath()
    {
        ChangeAnimationState(Enum_NameAnimationState.Death.ToString());
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
    }
    #endregion
    //public void SendDamage() //send to defender (target)
    //{
    //    if (isSendDamage == true)
    //    {
    //        damageInflicted = UnityEngine.Random.Range(detail.final_MinDamage, detail.final_MaxDamage + 1);
    //        target.damageTaken = damageInflicted;
    //        target.isApplyDamage = true;
    //        isSendDamage = false;
    //        damageInflicted = 0;
    //    }
    //}
    //public void ApplyDamage() //receive from attacker
    //{
    //    if (isApplyDamage == true)
    //    {
    //        detail.current_Life = detail.current_Life - (damageTaken - damageReduced);
    //        isApplyDamage = false;
    //        damageTaken = 0;
    //    }
    //}
    //private int Cal_DamageReduced()
    //{
    //    return detail.final_PhysicRes;
    //}

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
    //public void UseSkill()
    //{
    //    leftSkill = UpdateNameSkill("1");
    //    skillsSystem.leftSkill = leftSkill;

    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        Debug.LogWarning("Change Q to Left Mouse");
    //        skillsSystem.activeSkill = true;
    //    }
    //}
    //public string UpdateNameSkill(string skillName)
    //{
    //    return skillName;
    //}
}
