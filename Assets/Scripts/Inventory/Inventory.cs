using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        this.itemList = new List<Item>();
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
}
