using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApolloInjection : Item
{
    protected override void OnPickUp(Player player)
    {
        player.AttackCooldown /= 1.5f;
        player.wrench.damage /= 1.25f;
    }
}
