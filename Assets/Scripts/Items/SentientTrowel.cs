using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentientTrowel : Item
{
    [Header("Sentient Trowel")]
    [SerializeField] private Sprite angrySprite;
    public Sprite AngrySprite => angrySprite;
    protected override void OnPickUp(Player player)
    {
        SentientTrowelManager.Instance.AddTrowel();
    }
}
