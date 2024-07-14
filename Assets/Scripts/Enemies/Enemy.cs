using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : ProximityAttacker, IDamagable {

    [Header("Enemy Logic")]
    [SerializeField] protected float health = 50;
    [SerializeField] protected Image healthFill;
    private float startingHealth;

    protected override void Awake()
    {
        base.Awake();
        startingHealth = health;
    }

    public virtual void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
        healthFill.enabled = true;
        healthFill.fillAmount = health / startingHealth;
    }

}
