using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCloud : MonoBehaviour {


    private float maxRadius;
    private float growthTimer;


    public void Setup(float maxRadius) {
        this.maxRadius = maxRadius;
    }

    private void Update() {
        growthTimer += Time.deltaTime;
        if (growthTimer >= 1f) {
            transform.localScale = Vector3.one * Mathf.Lerp(0, maxRadius, 1f);
            Destroy(gameObject);
        }
        transform.localScale = Vector3.one * Mathf.Lerp(0, maxRadius, growthTimer);
    }

    private void OnTriggerEnter(Collider other) {
        
    }

}
