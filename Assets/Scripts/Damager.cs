using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other is IDamagable)
        {
            (other as IDamagable).Damage(damage);
        }
    }
}

public interface IDamagable
{
    public abstract void Damage(float amount);
}
