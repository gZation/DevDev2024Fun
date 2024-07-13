using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Enemy {


    [SerializeField] Transform peaProjectilePrefab;
    [SerializeField] Transform projectileSpawnPosition;
    [SerializeField] private float projectileSpeed = 5;
    [SerializeField] private float turnSpeed = 15;


    private Player target;


    protected override void Update() {
        base.Update();

        if (target != null) {
            Vector3 targetDirection = new Vector3(target.transform.position.x, 0, target.transform.position.z) - transform.position;
            transform.forward = Vector3.Slerp(transform.forward, targetDirection, Time.deltaTime * turnSpeed);
        }
    }

    protected override void Attack(Player player) {
        target = player;

        PeaProjectile peaProjectile = Instantiate(peaProjectilePrefab, projectileSpawnPosition.position, Quaternion.identity).GetComponent<PeaProjectile>();
        peaProjectile.Setup(target.transform.position - transform.position, damage, projectileSpeed);

        ResetAttackTimer();
    }

    private void OnTriggerExit(Collider other) {
        target = null;
    }

}
