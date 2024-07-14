using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour {


    [SerializeField] protected float damage = 30;
    [SerializeField] private float attackDelay = 3;


    protected float attackTimer;


    protected virtual void Update() {
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
    }

    protected virtual void ResetAttackTimer() {
        attackTimer = attackDelay;
    }

}
