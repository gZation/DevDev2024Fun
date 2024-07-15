using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Item
{
    [Header("Health")]
    [SerializeField] private float amount = 50f;
    private void Start()
    {
        isCollectible = false;
    }
    protected override void OnPickUp(Player player)
    {
        player.CurrHealth += amount;
    }
}
