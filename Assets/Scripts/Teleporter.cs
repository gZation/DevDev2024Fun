using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private float stayTime;
    private float cooldown;
    private bool teleporting;
    //private new ParticleSystem particleSystem;
    private void Awake()
    {
        //particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            cooldown = Time.time + stayTime;
            player.particleSystem.Play();
        }
            
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (cooldown > Time.time) return;
            player.particleSystem.Stop();
            player.transform.position = Vector3.forward * 5f;
            Camera.main.transform.position = Vector3.up * 8 + Vector3.forward * 1.5f;
            SceneManager.LoadSceneAsync(nextScene);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.particleSystem.Stop();
        }

    }
}
