using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeBush : Enemy {

    [Header("SporeBush")]
    [SerializeField] Transform sporeProjectilePrefab;
    [SerializeField] Transform projectileSpawnPosition;

    // SporeProjectileArgs
    [SerializeField] AnimationCurve launchCurve;
    [SerializeField] float projectileSpeed;
    [SerializeField] SphereCollider rangeCollider;

    // SporeCloudArgs
    [SerializeField] private AnimationCurve explosionCurve;
    [SerializeField] private float growthSpeed = 1.5f;
    [SerializeField] private float explosionRadius = 1;

    [SerializeField] private int numProjectiles = 6;


    protected override void Attack(Player player) {
        ResetAttackTimer();

        SporeProjectile.SporeProjectileArgs spArgs;
        spArgs.launchCurve = launchCurve;
        spArgs.speed = projectileSpeed;
        spArgs.range = rangeCollider.radius;
        spArgs.launchAngleY = 0;

        SporeCloud.SporeCloudArgs scArgs;
        scArgs.growthCurve = explosionCurve;
        scArgs.growthSpeed = growthSpeed;
        scArgs.maxScale = explosionRadius * 2;
        scArgs.damage = damage;

        for (int i = 0; i < numProjectiles; i++) {
            SporeProjectile sporeProjectile = Instantiate(sporeProjectilePrefab, projectileSpawnPosition.position, Quaternion.identity).GetComponent<SporeProjectile>();
            sporeProjectile.Setup(spArgs, scArgs);

            spArgs.launchAngleY += 2 * Mathf.PI / numProjectiles;
        }
        audioSource.Play();
    }

}
