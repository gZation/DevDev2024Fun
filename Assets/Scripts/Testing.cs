using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {


    private static int numTreasure;


    private void Awake() {
        numTreasure++;
    }


    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log(numTreasure);
        }
    }

}
