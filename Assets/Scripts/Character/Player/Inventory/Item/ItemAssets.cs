using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        Addressables.InitializeAsync().Completed += AddessableLoadCompleted;
    }
    public AssetReferenceSprite weaponTextureAssetReference;
    public AssetReferenceSprite posionTextureAssetReference;

    public GameObject itemUIPrefab;
    public Sprite weaponSprite;
    public Sprite potionSprite;
    public GameObject potionGo;
    public GameObject weaponGo;
    private void AddessableLoadCompleted(AsyncOperationHandle<IResourceLocator> obj)
    {
        weaponTextureAssetReference.LoadAssetAsync<Sprite>().Completed += (texture) =>
        {
            weaponSprite = texture.Result;
        };
        posionTextureAssetReference.LoadAssetAsync<Sprite>().Completed += (texture) =>
        {
            potionSprite = texture.Result;
            UnityEngine.SceneManagement.SceneManager.LoadScene("DungeonMap1");
        };
        //cubeAssetReference.InstantiateAsync().Completed += (go) =>
        //{
        //    go.Result.transform.position = new Vector3(2, 1, 0);
        //};

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
    public GameObject GetGameObject(Item item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                return weaponGo;
            case ItemType.Potion:
                return potionGo;
        }
        return null;
    }
}
