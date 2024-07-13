using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeBush : MonoBehaviour {


    [SerializeField] Transform sporeCloudPrefab;

    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;


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
        Debug.Log("Damaged player");
        attackTimer = attackDelay;
        Transform sporeCloudTransform = Instantiate(sporeCloudPrefab, transform.position, Quaternion.identity);
        SporeCloud sporeCloud = sporeCloudTransform.GetComponent<SporeCloud>();
        sporeCloud.Setup(GetComponent<SphereCollider>().radius * 2);
    }

}
