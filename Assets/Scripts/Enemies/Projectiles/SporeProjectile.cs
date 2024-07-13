using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeProjectile : MonoBehaviour {


    [Serializable]
    public struct SporeProjectileArgs {
        public AnimationCurve launchCurve;
        public float speed;
        public float range;
        public float launchAngleY;
    }


    [SerializeField] Transform sporeCloudPrefab;

    
    private SporeProjectileArgs spArgs;
    private SporeCloud.SporeCloudArgs scArgs;

    private Vector3 startingPosition;
    private float launchTimer;
    private bool isActive;


    public void Setup(SporeProjectileArgs sporeProjectileArgs, SporeCloud.SporeCloudArgs sporeCloudArgs) {
        spArgs = sporeProjectileArgs;
        scArgs = sporeCloudArgs;
        
        startingPosition = transform.position;
        isActive = true;
    }

    private void Update() {
        if (!isActive) {
            return;
        }

        launchTimer += Time.deltaTime * spArgs.speed;
        if (launchTimer >= 1f) {
            SporeCloud sporeCloud = Instantiate(sporeCloudPrefab, transform.position, Quaternion.identity).GetComponent<SporeCloud>();
            sporeCloud.Setup(scArgs);
            Destroy(gameObject);
        }

        spArgs.launchCurve.Evaluate(launchTimer);

        Vector3 newPosition = startingPosition;
        newPosition.x += launchTimer * MathF.Cos(spArgs.launchAngleY) * spArgs.range;
        newPosition.y = spArgs.launchCurve.Evaluate(launchTimer) * spArgs.range;
        newPosition.z += launchTimer * MathF.Sin(spArgs.launchAngleY) * spArgs.range;
        transform.position = newPosition;
    }

}
