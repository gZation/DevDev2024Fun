using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Description:
/// Greatly Increases Speed at the cost of moving forever
/// </summary>
public class JetPowerBoots : Item
{
    protected override void OnPickUp(Player player)
    {
        player.ApplyModifier<AdjustSpeed, AdjustSpeedData>(new AdjustSpeedData(3f));
        player.infiMove = true;
    }
}
