using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeBush : MonoBehaviour, IDamagable {


    [SerializeField] Transform sporeCloudPrefab;

    [SerializeField] private float health = 50;
    [SerializeField] private float damage = 30;
    [SerializeField] private float attackSpeed = 1;
    [SerializeField] private float attackDelay = 3;


    private float attackTimer;


    private void Update() {
        if (attackTimer > 0) {
            attackTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.TryGetComponent(out Player player) && attackTimer <= 0) {
            Attack();
        }
    }

    private void Attack() {
        attackTimer = attackDelay;
        SporeCloud sporeCloud = Instantiate(sporeCloudPrefab, transform.position, Quaternion.identity).GetComponent<SporeCloud>();
        sporeCloud.Setup(GetComponent<SphereCollider>().radius, damage, attackSpeed);
    }

    public void Damage(float amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
