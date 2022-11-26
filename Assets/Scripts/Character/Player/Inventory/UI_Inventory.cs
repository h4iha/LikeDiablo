using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    private GameObject itemUIPrefab;
    private Inventory inventory;
    [SerializeField] private Transform inventoryParent;
    [SerializeField] Player player;
    private void Start()
    {
        itemUIPrefab = ItemAssets.Instance.itemUIPrefab;
        RefreshInventory();
    }
    public void RefreshInventory()
    {
        foreach (Transform transform in inventoryParent)
        {
            Destroy(transform.gameObject);
        }

        foreach (var item in inventory.GetItemList())
        {
            GameObject newGO = Instantiate(itemUIPrefab, inventoryParent);
            ItemPrefab icon_Prefab = newGO.GetComponent<ItemPrefab>();
            icon_Prefab.SetTextAndIcon(item);
            icon_Prefab.onItemPickUp = () =>
            {
                inventory.PickUpItem(item);
                icon_Prefab.SetTextAndIcon(item);
            };
            icon_Prefab.onItemDrop = () =>
            {
                Vector3 position = player.transform.position + Vector3.up * 3 + Vector3.forward * 2;
                Debug.Log(ItemWorldSpawner.Instance);
                inventory.DropItem(item, 1);
                icon_Prefab.SetTextAndIcon(item);
                ItemWorldSpawner.Instance.Spawn(position, item);
            };
            icon_Prefab.onItemUsed = () =>
            {
                //
                if (item.type == ItemType.Potion) inventory.UseItem(item);
            };
        }
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.onInventoryUpdated = RefreshInventory;

    }
}
