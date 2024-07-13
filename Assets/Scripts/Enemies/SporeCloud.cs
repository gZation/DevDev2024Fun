using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCloud : MonoBehaviour {


    private float maxScale;
    private float growthTimer;
    private float damage;
    private float growthSpeed;


    public void Setup(float maxRadius, float damage, float growthSpeed) {
        maxScale = maxRadius * 2;
        this.damage = damage;
        this.growthSpeed = growthSpeed;
    }

    private void Update() {
        growthTimer += Time.deltaTime * growthSpeed;
        if (growthTimer >= 1f) {
            transform.localScale = Vector3.one * Mathf.Lerp(0, maxScale, 1f);
            Destroy(gameObject);
        }
        transform.localScale = Vector3.one * Mathf.Lerp(0, maxScale, growthTimer);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player player)) {
            player.Damage(damage);
        }
    }

}
