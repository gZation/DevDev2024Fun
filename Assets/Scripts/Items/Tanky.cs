using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanky : Item
{
    protected override void OnPickUp(Player player)
    {
        player.speed -= 1;
        player.MaxHealth += 200f;
    } 
}
