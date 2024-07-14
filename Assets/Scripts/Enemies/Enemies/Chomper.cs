using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : Enemy {

    [Header("Chomper")]
    [SerializeField] private Animator animator;
    [SerializeField] private bool singleHit = true;


    private bool hasHitThisAttack;


    protected override void Attack(Player player) {
        ResetAttackTimer();

        hasHitThisAttack = false;
        animator.SetTrigger("Attack");
    }

    private void OnCollisionEnter(Collision collision) {
        if (!singleHit || !hasHitThisAttack) {
            if (collision.gameObject.TryGetComponent(out Player player)) {
                player.Damage(damage);
                hasHitThisAttack = true;
            }
        }
    }

}
