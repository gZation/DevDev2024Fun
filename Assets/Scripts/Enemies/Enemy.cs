using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamagable {


    [SerializeField] protected float health = 50;
    [SerializeField] protected float damage = 30;
    [SerializeField] private float attackDelay = 3;


    private float attackTimer;


    protected virtual void Update() {
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
    }

    protected virtual void OnTriggerStay(Collider other) {
        if (other.gameObject.TryGetComponent(out Player player) && attackTimer <= 0) {
            Attack(player);
        }
    }

    protected abstract void Attack(Player player);

    protected virtual void ResetAttackTimer() {
        attackTimer = attackDelay;
    }

    public virtual void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

}
