using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCloud : MonoBehaviour {


    [Serializable]
    public struct SporeCloudArgs {
        public AnimationCurve growthCurve;
        public float growthSpeed;
        public float maxScale;
        public float damage;
    }


    private SporeCloudArgs args;
    private float growthTimer;


    public void Setup(SporeCloudArgs args) {
        this.args = args;
    }

    private void Update() {
        growthTimer += Time.deltaTime * args.growthSpeed;
        if (growthTimer >= 1f) {
            Destroy(gameObject);
        }
        transform.localScale = args.growthCurve.Evaluate(growthTimer) * args.maxScale * Vector3.one;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out Player player)) {
            player.Damage(args.damage);
        }
    }

}
