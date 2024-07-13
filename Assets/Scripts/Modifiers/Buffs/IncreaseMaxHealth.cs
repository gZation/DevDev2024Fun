using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxHealth : PlayerModifier<IncreaseMaxHealthData>
{
    public override void OnApply(IncreaseMaxHealthData data)
    {
        _data = data;
        _player.maxHealth += _data.healthIncrease;
    }

    public override void OnRemove()
    {
        _player.maxHealth -= _data.healthIncrease;
    }
}

public class IncreaseMaxHealthData : ModifierData
{
    public float healthIncrease;
}
