using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Enemy {

    [Header("PeaShooter")]
    [SerializeField] Transform peaShooterRotateTransform;
    [SerializeField] Transform projectileSpawnPosition;
    [SerializeField] Transform peaProjectilePrefab;
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private bool useHoming = false;
    [SerializeField] private float projectileHomingSpeed;
    [SerializeField] private float projectileHomingAcceleration;
    [SerializeField] private float turnSpeed = 15;


    private Player target;


    protected override void Update() {
        base.Update();

        if (target != null) {
            Vector3 targetDirection = new Vector3(target.transform.position.x, 0, target.transform.position.z) - transform.position;
            peaShooterRotateTransform.forward = Vector3.Slerp(peaShooterRotateTransform.forward, targetDirection, Time.deltaTime * turnSpeed);
        }
    }

    protected override void Attack(Player player) {
        target = player;

        PeaProjectile peaProjectile = Instantiate(peaProjectilePrefab, projectileSpawnPosition.position, Quaternion.identity).GetComponent<PeaProjectile>();
        if (useHoming) {
            peaProjectile.Setup(player, damage, projectileSpeed, projectileHomingSpeed, projectileHomingAcceleration);
        } else {
            peaProjectile.Setup(player, damage, projectileSpeed);
        }
        audioSource.Play();
        ResetAttackTimer();
    }

    private void OnTriggerExit(Collider other) {
        target = null;
    }

}
