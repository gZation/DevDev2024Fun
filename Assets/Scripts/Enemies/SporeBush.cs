using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeBush : Enemy {


    [SerializeField] Transform sporeCloudPrefab;
    [SerializeField] private float growthSpeed = 1;


    protected override void Attack(Player player) {
        base.Attack(player);
        SporeCloud sporeCloud = Instantiate(sporeCloudPrefab, transform.position, Quaternion.identity).GetComponent<SporeCloud>();
        sporeCloud.Setup(GetComponent<SphereCollider>().radius, damage, growthSpeed);
    }

}
