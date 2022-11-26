using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillPrefab : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text amount;
    [SerializeField] public GameObject itemPrefab;

    public Action onSkillLevelUp;
    public Action onSkillUsed;
    public void SetTextAndIcon(Item item)
    {
        icon.sprite = ItemAssets.Instance.GetSprite(item);
        amount.text = item.amount.ToString();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        // use the item
        if (pointerEventData.button == PointerEventData.InputButton.Left)
            onSkillLevelUp?.Invoke();
        // drop the item;
        if (pointerEventData.button == PointerEventData.InputButton.Middle)
            onSkillUsed?.Invoke();
    }
    public void DestroyIcon()
    {
        Destroy(gameObject);
    }
}
