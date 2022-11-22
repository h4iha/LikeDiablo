using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private GameObject itemUIPrefab;
    private Inventory inventory;
    [SerializeField] private Transform inventoryParent;
    private void Start()
    {
        itemUIPrefab = ItemAssets.Instance.itemUIPrefab;
        PrefabsInventory();
    }
    public void PrefabsInventory()
    {
        foreach (var item in inventory.GetItemList())
        {
            GameObject newGO = Instantiate(itemUIPrefab, inventoryParent);
            newGO.GetComponent<Icon_Prefab>().SetTextAndIcon(item);
        }
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
    }
    
}
