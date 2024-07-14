using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemCard : MonoBehaviour
{
    [SerializeField] private Image cardSprite;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI buff;
    [SerializeField] private TextMeshProUGUI debuff;
    [SerializeField] private TextMeshProUGUI lore;

    public void UpdateCardDetails(Item item)
    {
        cardSprite.sprite = item.ItemSprite;
        cardName.text = item.ItemName;
        buff.text = item.Buff;
        debuff.text = item.Debuff;
        lore.text = item.Lore;
    }

    public void ModifySpireProfile(Sprite sprite)
    {
        cardSprite.sprite = sprite;
    }
}
