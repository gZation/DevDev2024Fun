using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
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
    private bool preState;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {

            preState = player.infiMove;
            player.infiMove = false;
            player.OnMove(null);
            cooldown = Time.time + stayTime;
            particleSystem.Play();
            player.particleSystem.Play();
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            audioSource.Play();
        }
            
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
            player.infiMove = preState;
            audioSource.Stop();
            particleSystem.Stop();
            player.particleSystem.Stop();
        }

    }
}
