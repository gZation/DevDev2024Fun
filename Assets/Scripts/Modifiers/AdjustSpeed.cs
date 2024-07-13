using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSpeed : PlayerModifier<AdjustSpeedData>
{
    public override void OnApply(AdjustSpeedData data)
    {
        _data = data;
        _player.speed *= _data.scalar;
    }

    public override void OnRemove()
    {
        _player.maxHealth /= _data.scalar;
    }
}

public class AdjustSpeedData : ModifierData
{
    public float scalar;
    public AdjustSpeedData(float scalar)
    {
        this.scalar = scalar;
    }
}
