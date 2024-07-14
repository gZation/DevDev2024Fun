using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attacker : MonoBehaviour {

    [Header("Attacker")]
    [SerializeField] protected float damage = 30;
    [SerializeField] private float attackDelay = 3;
    protected AudioSource audioSource;


    protected float attackTimer;
    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Update() {
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
    }

    protected virtual void ResetAttackTimer() {
        attackTimer = attackDelay;
    }

}
