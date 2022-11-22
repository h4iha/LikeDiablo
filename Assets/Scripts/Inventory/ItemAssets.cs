using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance;
    private void Awake()
    {
        Instance = this;
    }
    public GameObject itemUIPrefab;
    public Sprite weaponSprite;
    public Sprite potionSprite;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public Sprite GetSprite(Item item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                return weaponSprite;
            case ItemType.Potion:
                return potionSprite;
        }
        return null;

    }
}
