using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanky : Item
{
    protected override void OnPickUp(Player player)
    {
        player.ApplyModifier<AdjustMaxHealth, AdjustMaxHealthData>(new AdjustMaxHealthData(200f));
        player.ApplyModifier<AdjustSpeed, AdjustSpeedData>(new AdjustSpeedData(0.5f));
    } 
}
