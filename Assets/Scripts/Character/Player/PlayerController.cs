using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public EnemyController target;
    [SerializeField] public GameObject enemyDetail;
    [SerializeField] public WeaponScript weaponTarget;
    [SerializeField] public Transform inventoryPrefabs;
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
    [SerializeField] bool isSendDamage;
    [SerializeField] int damageInflicted;
    [SerializeField] public bool isApplyDamage;
    [SerializeField] public int damageTaken;
    [SerializeField] public int damageReduced;
    [Space]
    [Header("Details")]
    [SerializeField] PlayerDetails playerDetails;
    [SerializeField] SkillsSystem skillsSystem;
    [Header("Skill")]
    [SerializeField] public string leftSkill;

    [SerializeField] private UI_Inventory ui_Inventory;
    public Inventory inventory;
    //[SerializeField] public Skill_1 RightSkill;
    private void Awake()
    {
        inventory = new Inventory(HandleUseItem);
        Debug.Log(inventory);
        ui_Inventory.SetInventory(inventory);
        Debug.LogWarning(inventory.GetItemList().Count);
    }

    private void HandleUseItem(Item item)
    {
        Debug.Log(item.type);
        if (item.type == ItemType.Potion)
        {
            playerDetails.current_Life += 5;
        }
    }
    private void Start()
    {
        DoGetComponentStart();
        ChangeAnimationState(Enum_NameAnimationState.Idle.ToString());
        leftSkill = "1";
        skillsSystem.leftSkill = leftSkill;
    }
    private void Update()
    {
        removeTarget();
        UpdateCollider();
        if (playerDetails.current_Life > 0)
        {
            if (currentState != Enum_NameAnimationState.Attack.ToString())
            {
                DoIdle();
                DoWalkingPointToClick();
                UseSkill();
            }
            DoMeleeAttack();
            SendDamage();
            ApplyDamage();
        }
        else DoDeath();
    }
    private void DoGetComponentStart()
    {
        enemyDetail = GameObject.Find("Enemy Detail Bar");
        playerDetails = GetComponent<PlayerDetails>();
        skillsSystem = GetComponent<SkillsSystem>();
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
        if (Vector3.Distance(transform.position, agent.destination) <= agent.stoppingDistance && isCanAttack == true && target != null)
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
    private void DoWalkingPointToClick() // Player with Right Click
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue))
            {
                target = hit.transform.GetComponent<EnemyController>();
                //weaponTarget = hit.transform.GetComponent<WeaponScript>();
                if (target != null && weaponTarget == null)
                {
                    isCanAttack = true;
                    agent.destination = target.transform.position;
                    agent.stoppingDistance = (float) (playerDetails.final_AttackRange/100);
                    if (Vector3.Distance(transform.position, target.transform.position) >= agent.stoppingDistance)
                        ChangeAnimationState(Enum_NameAnimationState.Walking.ToString());
                }
                else
                {
                    agent.stoppingDistance = 0f;
                    agent.destination = hit.point;
                    ChangeAnimationState(Enum_NameAnimationState.Walking.ToString());
                }
            }
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
            damageInflicted = UnityEngine.Random.Range(playerDetails.final_MinDamage, playerDetails.final_MaxDamage + 1);
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
            playerDetails.current_Life = playerDetails.current_Life - (damageTaken - damageReduced);
            isApplyDamage = false;
            damageTaken = 0;
        }
    }
    private int Cal_DamageReduced()
    {
        return playerDetails.final_PhysicRes;
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
    public void UseSkill()
    {
        leftSkill = UpdateNameSkill("1");
        skillsSystem.leftSkill = leftSkill;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.LogWarning("Change Q to Left Mouse");
            skillsSystem.activeSkill = true;
        }
    }
    public string UpdateNameSkill(string skillName)
    {
        return skillName;
    }
    private void removeTarget()
    {
        if (target != null && target.gameObject.GetComponent<NavMeshAgent>().isActiveAndEnabled == false) target = null;
    }
}
