using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentientTrowelManager : MonoBehaviour {


    public static SentientTrowelManager Instance { get; private set; }



    [SerializeField] private Transform sentientTrowelParentPrefab;
    [SerializeField] private float rotateSpeed = 150;
    [SerializeField] private int initialTrowelCount = 0;


    public enum State {
        Idle,
        SelfAttack
    }

    public State state = State.Idle;


    private List<Transform> trowelParents;
    private List<Vector3> previousPositions;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("There is more than one SentientTrowelManager " + this);
        }

        trowelParents = new List<Transform>();
        previousPositions = new List<Vector3>();

        for (int i = 0; i < initialTrowelCount; i++) {
            AddTrowel();
        }
    }

    private void Update() {
        switch (state) {
            case State.Idle:
                if (IsStationary()) {
                    state = State.SelfAttack;
                    SetSelfAttack(true);
                } else {
                    transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
                    previousPositions.Add(transform.position);
                    if (previousPositions.Count >= 5) {
                        previousPositions.RemoveAt(0);
                    }
                }
                break;
            case State.SelfAttack:
                if (!IsStationary()) {
                    state = State.Idle;
                    SetSelfAttack(false);
                }
                break;
        }
    }

    public void AddTrowel() {
        trowelParents.Add(Instantiate(sentientTrowelParentPrefab, transform));
        UpdateTrowels();
    }

    private void UpdateTrowels() {
        float angle = 0;
        foreach (Transform trowelParent in trowelParents) {
            trowelParent.localEulerAngles = new Vector3(0, angle * Mathf.Rad2Deg, 0);
            angle += 2 * Mathf.PI / trowelParents.Count;
        }
    }

    private void SetSelfAttack(bool selfAttack) {
        foreach (Transform trowelParent in trowelParents) {
            trowelParent.GetComponentInChildren<Animator>().SetBool("SelfAttack", selfAttack);
        }
    }

    private bool IsStationary() {
        if (previousPositions == null || previousPositions.Count == 0) {
            return false;
        }

        foreach (Vector3 position in previousPositions) {
            if (position != transform.position) {
                return false;
            }
        }

        return true;
    }

}
