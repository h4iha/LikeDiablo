using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{
    public static ItemWorldSpawner Instance;
    private void Awake()
    {

        Instance = this;
    }

    public GameObject Spawn(Vector3 position, Item item)
    {
        GameObject gameObject = Instantiate(ItemAssets.Instance.GetGameObject(item), position, Quaternion.identity);
        return gameObject;
    }
}
