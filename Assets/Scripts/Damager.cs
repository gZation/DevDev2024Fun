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
        if (other is IDamagable && !ignoreList.Contains(other.gameObject))
        {
            (other as IDamagable).Damage(damage);
        }
    }
}

public interface IDamagable
{
    public abstract void Damage(float amount);
}
