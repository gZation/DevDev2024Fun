using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Enemy {


    [SerializeField] Transform peaBulletPrefab;
    [SerializeField] private float projectileSpeed = 1;


    protected override void Attack(Player player) {
        base.Attack(player);
        SporeCloud sporeCloud = Instantiate(peaBulletPrefab, transform.position, Quaternion.identity).GetComponent<SporeCloud>();
        sporeCloud.Setup(GetComponent<SphereCollider>().radius, damage, projectileSpeed);
    }

}
