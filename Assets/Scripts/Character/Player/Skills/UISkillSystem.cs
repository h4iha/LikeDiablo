using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISkillSystem : MonoBehaviour
{
    private GameObject skillUIPrefab;
    private SkillSystem skillSystem;
    [SerializeField] private Transform skillSystemParent;
    private void Start()
    {
        //itemUIPrefab = ItemAssets.Instance.itemUIPrefab;
        RefreshInventory();
    }
    public void RefreshInventory()
    {

    }
}
