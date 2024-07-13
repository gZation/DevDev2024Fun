using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanky : Item
{
    protected override void OnPickUp(Player player)
    {
        player.speed /= 2f;
        player.MaxHealth += 200f;
    } 
}
