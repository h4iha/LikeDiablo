using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Icon_Prefab : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text amount;
    [SerializeField] public GameObject itemPrefab;
    public void SetTextAndIcon(Item item)
    {
        Debug.Log(item);
        icon.sprite = ItemAssets.Instance.GetSprite(item);
        amount.text = item.amount.ToString();
    }
}
