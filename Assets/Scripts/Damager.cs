using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagable damagable) && !ignoreList.Contains(other.gameObject))
        {
            damagable.Damage(damage);
        }
    }
}

public interface IDamagable
{
    public abstract void Damage(float amount);
}
