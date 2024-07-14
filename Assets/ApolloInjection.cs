using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApolloInjection : Item
{
    protected override void OnPickUp(Player player)
    {
        player.speed *= 3;
    }
}
