using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : ProximityAttacker, IDamagable {


    [SerializeField] protected float health = 50;


    public virtual void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
