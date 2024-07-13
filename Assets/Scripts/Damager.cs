using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Damager : MonoBehaviour
{
    public float damage;
    public GameObject[] ignoreList;
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
