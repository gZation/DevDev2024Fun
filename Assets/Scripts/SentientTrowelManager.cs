using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentientTrowelManager : MonoBehaviour {


    public static SentientTrowelManager Instance { get; private set; }



    [SerializeField] private Transform trowelPrefab;
    [SerializeField] private float rotateSpeed = 150;
    [SerializeField] private float rotateRadius = 1;


    private int trowelCount;
    private List<Transform> trowels;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("There is more than one SentientTrowelManager " + this);
        }

        trowels = new List<Transform>();
    }

    private void Update() {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }

    public void AddTrowel() {
        trowelCount++;
        trowels.Add(Instantiate(trowelPrefab, transform));
        UpdateTrowels();
    }

    private void UpdateTrowels() {
        float angle = 0;
        foreach (Transform trowel in trowels) {
            trowel.localPosition = new Vector3(rotateRadius * Mathf.Cos(angle), 1, rotateRadius * Mathf.Sin(angle));
            trowel.localEulerAngles = new Vector3(0, angle * Mathf.Rad2Deg, 0);
            angle += 2 * Mathf.PI / trowels.Count;
        }
    }

}
