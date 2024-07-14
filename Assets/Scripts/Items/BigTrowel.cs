using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTrowel : Item
{
    protected override void OnPickUp(Player player)
    {
        player.UpgradeTrowel();
        player.AttackCooldown *= 1.5f;
    }
}
