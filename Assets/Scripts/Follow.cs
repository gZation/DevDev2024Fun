using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {


    [SerializeField] Transform followTarget;


    private void Update() {
        transform.position = followTarget.position;
    }

}
