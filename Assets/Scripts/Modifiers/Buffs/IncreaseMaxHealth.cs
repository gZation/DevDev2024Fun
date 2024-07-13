using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxHealth : PlayerModifier
{
    private IncreaseMaxHealthData data;
    public override void OnApply()
    {
        _player.maxHealth += data.healthIncrease;
    }

    public override void OnRemove()
    {
        _player.maxHealth -= data.healthIncrease;
    }
}

public class IncreaseMaxHealthData : ModifierData
{
    public float healthIncrease;
}
