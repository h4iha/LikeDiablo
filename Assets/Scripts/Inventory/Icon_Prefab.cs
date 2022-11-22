using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Icon_Prefab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text amount;
    [SerializeField] public GameObject itemPrefab;

    public Action onItemDrop;

    public Action onItemUsed;
    public void SetTextAndIcon(Item item)
    {
        icon.sprite = ItemAssets.Instance.GetSprite(item);
        amount.text = item.amount.ToString();
    }
    public void OnPointerClick( PointerEventData pointerEventData)
    {
        // use the item
        if (pointerEventData.button == PointerEventData.InputButton.Left)
            onItemUsed?.Invoke();
        // drop the item;
        if (pointerEventData.button == PointerEventData.InputButton.Middle)
            onItemDrop?.Invoke();
    }
    public void DestroyIcon()
    {
        Destroy(gameObject);
    }

}
