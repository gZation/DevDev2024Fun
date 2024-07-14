using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Thorn : TimedAttacker {


    [SerializeField] private Animator animator;
    [SerializeField] private bool singleHitPerAttack = true;


    private bool hasHitThisAttack;


    protected override void Attack() {
        ResetAttackTimer();

        hasHitThisAttack = false;
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other) {
        if (!singleHitPerAttack || !hasHitThisAttack) {
            if (other.gameObject.TryGetComponent(out Player player)) {
                player.Damage(damage);
                hasHitThisAttack = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!singleHitPerAttack || !hasHitThisAttack) {
            if (collision.gameObject.TryGetComponent(out Player player)) {
                player.Damage(damage);
                hasHitThisAttack = true;
            }
        }
    }

}
