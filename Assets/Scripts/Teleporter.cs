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
    private AudioSource audioSource;
    private new ParticleSystem particleSystem;
    private void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            cooldown = Time.time + stayTime;
            particleSystem.Play();
            player.particleSystem.Play();
            audioSource.Play();
        }
            
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (cooldown > Time.time) return;
            if (nextScene.Contains("level"))
            {
                
                player.particleSystem.Stop();
                player.transform.position = Vector3.forward * 5f;
                Camera.main.transform.position = Vector3.up * 8 + Vector3.forward * 1.5f;
                DontDestroyOnLoad(player.transform.parent.gameObject);
            }
            else
            {
                Destroy(player.transform.parent.gameObject);
            }
            
            SceneManager.LoadSceneAsync(nextScene);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            audioSource.Stop();
            particleSystem.Stop();
            player.particleSystem.Stop();
        }

    }
}
