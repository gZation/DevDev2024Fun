using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemCard : MonoBehaviour
{
    [SerializeField] private Image cardSprite;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI buff;
    [SerializeField] private TextMeshProUGUI debuff;
    [SerializeField] private TextMeshProUGUI lore;
    private Item item;

    public void UpdateCardDetails(Item item)
    {
        this.item = item;
        cardSprite.sprite = item.ItemSprite;
        cardName.text = item.ItemName;
        buff.text = item.Buff;
        debuff.text = item.Debuff;
        lore.text = item.Lore;

        if (item.GetComponent<SentientTrowel>())
        {
            SentientTrowelManager.Instance.OnIdleState += GoHappy;
            SentientTrowelManager.Instance.OnSelfAttackState += GoAngry;
        }
    }
    private void GoHappy()
    {
        cardSprite.sprite = ((SentientTrowel)item).ItemSprite;
    }
    private void GoAngry()
    {
        cardSprite.sprite = ((SentientTrowel)item).AngrySprite;
    }

}
