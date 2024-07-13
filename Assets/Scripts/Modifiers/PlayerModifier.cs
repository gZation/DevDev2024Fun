using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerModifier : MonoBehaviour
{
    protected Player _player;   
    protected void Awake()
    {
        _player = GetComponentInParent<Player>();
    }
    public abstract void OnApply();
    public abstract void OnRemove();
    public void OnDestroy()
    {
        OnRemove();
    }
}

public abstract class ModifierData{ }
