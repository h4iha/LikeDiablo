using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPrefab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text amount;
    [SerializeField] public GameObject itemPrefab;

    public Action onItemDrop;

    public Action onItemUsed;
    public Action onItemPickUp;
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
    public void IncreaseAmount(Item item)
    {
        onItemPickUp?.Invoke();
    }
    public void DestroyIcon()
    {
        Destroy(gameObject);
    }

}
