using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaProjectile : Damager {


    private Player player;
    private float projectileSpeed;
    private bool useHoming;
    private float homingSpeed;
    private float homingAcceleration;
    private Vector3 direction;


    public void Setup(Player player, float damage, float projectileSpeed) {
        this.player = player;
        this.damage = damage;
        this.projectileSpeed = projectileSpeed;

        useHoming = false;
        direction = (player.transform.position - new Vector3(transform.position.x, 0, transform.position.z)).normalized;
    }

    public void Setup(Player player, float damage, float projectileSpeed, float homingSpeed, float homingAcceleration) {
        Setup(player, damage, projectileSpeed);
        this.homingSpeed = homingSpeed;
        this.homingAcceleration = homingAcceleration;

        useHoming = true;
    }

    private void Update() {
        if (useHoming) {
            direction = Vector3.Slerp(direction, (player.transform.position - new Vector3(transform.position.x, 0, transform.position.z)).normalized, Time.deltaTime * homingSpeed);
            homingSpeed += homingAcceleration * Time.deltaTime;
        }

        transform.position += direction * projectileSpeed * Time.deltaTime;
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        Destroy(gameObject);
    }

}
