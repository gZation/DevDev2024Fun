using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Enemy {


    [SerializeField] Transform peaBulletPrefab;
    [SerializeField] Transform bulletSpawnPosition;
    [SerializeField] private float projectileSpeed = 3;


    protected override void Attack(Player player) {
        base.Attack(player);
        transform.LookAt(player.transform.position);
        PeaBullet bullet = Instantiate(peaBulletPrefab, bulletSpawnPosition.position, Quaternion.identity).GetComponent<PeaBullet>();
        bullet.Setup(transform.forward, damage, projectileSpeed);
    }

}
