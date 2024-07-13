using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerModifier<D>  : MonoBehaviour
    where D : ModifierData
{
    protected Player _player;
    protected D _data;
    
    protected void Awake()
    {
        _player = GetComponentInParent<Player>();
    }
    public abstract void OnApply(D data);
    public abstract void OnRemove();
    public void OnDestroy()
    {
        OnRemove();
    }
}

public abstract class ModifierData { }
