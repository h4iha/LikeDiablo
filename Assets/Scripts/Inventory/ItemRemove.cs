using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemove : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] WeaponScript weapon;
    [SerializeField] private Transform inventoryPrefabs;
    [SerializeField] private Transform unknowedItem;
    [SerializeField] private int position;
    private void Start()
    {
        unknowedItem = GameObject.FindGameObjectWithTag("UnknowedItem").transform;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        inventoryPrefabs = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3);
        position = inventoryPrefabs.childCount - 1;
        weapon = inventoryPrefabs.GetChild(position).GetComponent<WeaponScript>();
    }
    public void Remove()
    {
        Debug.Log("1");
        playerController.RemoveItemInInventory(weapon.item);
        weapon.transform.SetParent(unknowedItem);
        weapon.GetComponent<Rigidbody>().useGravity = true;
        weapon.gameObject.active = true;
        Destroy(gameObject);
    }
}
