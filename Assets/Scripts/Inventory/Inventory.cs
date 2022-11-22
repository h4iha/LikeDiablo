using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Action onInventoryUpdated;
    private Action<Item> onItemUsed;
    public Inventory(Action<Item> onItemUsed)
    {
        this.itemList = new List<Item>();
        this.onItemUsed = onItemUsed;

        itemList.Add(new Item() { type = ItemType.Weapon, amount = 1 });
        itemList.Add(new Item() { type = ItemType.Potion, amount = 3 });
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }

    public void DropItem(Item item, int amount = 1)
    {

        DecreaseItemAmount(item, amount);
        onInventoryUpdated?.Invoke();
    }

    public void UseItem(Item item)
    {
        DecreaseItemAmount(item, 1);
        onInventoryUpdated?.Invoke();
        onItemUsed?.Invoke(item);
    }

    private void DecreaseItemAmount(Item item, int amount)
    {
        Item itemToRemove = null;
        foreach (Item itemInList in itemList)
        {
            if (itemInList.type == item.type)
            {
                if (itemInList.IsStackable() && itemInList.amount > 1)
                {
                    itemInList.amount -= amount;
                }
                else
                {
                    itemToRemove = item;
                }
            }
        }
        if (itemToRemove != null)
        {
            itemList.Remove(itemToRemove);
        }
    }


}
