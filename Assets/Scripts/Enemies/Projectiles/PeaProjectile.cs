using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaProjectile : Damager {


    private Vector3 direction;
    private float projectileSpeed;


    public void Setup(Vector3 direction, float damage, float projectileSpeed) {
        this.direction = direction;
        this.damage = damage;
        this.projectileSpeed = projectileSpeed;
    }

    private void Update() {
        transform.position += direction * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player player)) {
            player.Damage(damage);
        }
        Destroy(gameObject);
    }

}
