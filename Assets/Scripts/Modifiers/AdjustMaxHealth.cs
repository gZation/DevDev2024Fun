using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMaxHealth : PlayerModifier<AdjustMaxHealthData>
{
    public override void OnApply(AdjustMaxHealthData data)
    {
        if (data == null)
        {
            Debug.LogError("Cannot apply null modifier data");
            return;
        }
        _data = data;
        _player.maxHealth += _data.healthIncrease;
    }

    public override void OnRemove()
    {
        _player.maxHealth -= _data.healthIncrease;
    }
}

public class AdjustMaxHealthData : ModifierData
{
    public float healthIncrease;
    public AdjustMaxHealthData(float healthIncrease)
    {
        this.healthIncrease = healthIncrease;
    }
}
