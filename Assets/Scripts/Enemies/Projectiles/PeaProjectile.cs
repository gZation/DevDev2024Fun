using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaProjectile : Damager {


    private Player player;
    private float projectileSpeed;
    private bool useHoming;
    private float homingSpeed;
    private float homingAcceleration;
    [SerializeField] private Vector3 direction;


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
            if (player == null) Destroy(gameObject);

            // Old - ignore y-level
            //direction = Vector3.Slerp(direction, (new Vector3(player.transform.position.x, 0, player.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z)).normalized, Time.deltaTime * homingSpeed);
            
            // New - include y-level (zero out dy if y positions are within margin)
            direction = Vector3.Slerp(direction, (player.transform.position - transform.position).normalized, Time.deltaTime * homingSpeed);
            float yMargin = 0.1f;
            float playerTargetingHeight = 1.3f;
            if (Mathf.Abs(player.transform.position.y + playerTargetingHeight - transform.position.y) < yMargin) {
                direction.y = 0;
            }
            
            homingSpeed += homingAcceleration * Time.deltaTime;
        }

        transform.position += direction * projectileSpeed * Time.deltaTime;
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        Debug.Log(other.gameObject);
        Destroy(gameObject);
    }

}
