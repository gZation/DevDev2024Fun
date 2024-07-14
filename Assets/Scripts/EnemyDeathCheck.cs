using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCheck : MonoBehaviour
{
    [SerializeField] private Transform enemies;
    [SerializeField] private Animator animator;
    private AudioSource audioSource;
    private bool beaten;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (enemies.transform.childCount > 0 || beaten) return;
        beaten = true;
        animator.Play("reveal");
        audioSource.Play();
    }
}
