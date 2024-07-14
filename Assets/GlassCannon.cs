using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCannon : Item
{
    [Header("Glass Cannon")]
    [SerializeField] private float healthDecrease = 100f;
    [SerializeField] private float damageIncrease = 10f;
    protected override void OnPickUp(Player player)
    {
        player.MaxHealth -= healthDecrease;
        player.wrench.damage += damageIncrease;
    }
}
