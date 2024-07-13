using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCloud : Damager {


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
        damage = args.damage;
    }

    private void Update() {
        growthTimer += Time.deltaTime * args.growthSpeed;
        if (growthTimer >= 1f) {
            Destroy(gameObject);
        }
        transform.localScale = args.growthCurve.Evaluate(growthTimer) * args.maxScale * Vector3.one;
    }

}
