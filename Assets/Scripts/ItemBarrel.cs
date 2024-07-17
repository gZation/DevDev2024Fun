using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarrel : MonoBehaviour, IDamagable
{
    [SerializeField] private Item[] m_items;
    private AudioSource audioSource;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private new ParticleSystem particleSystem;
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        if (meshRenderer == null || !meshRenderer.enabled)
        {
            Debug.LogError("Missing Renderer or Renderer is not enabled");
            return;
        }
        meshCollider = GetComponentInChildren<MeshCollider>();
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponent<ParticleSystem>();
    }
    public void Damage(float amount)
    {
        if (!meshRenderer.enabled) return;
        audioSource?.Play();
        float total = 0f;
        foreach (Item item in m_items)
        {
            total += item.Weight;
        }
        float rand = Random.Range(0, total);
        foreach (Item item in m_items) 
        {   
            rand -= item.Weight;
            if (rand <= 0)
            {
                GameObject go = Instantiate(item).gameObject;
                go.transform.position = transform.position + Vector3.up * 3f;
                go.GetComponent<Rigidbody>().AddForce(Vector3.up * 2f, ForceMode.Impulse);
                audioSource?.Play();
                meshRenderer.enabled = false;
                meshCollider.enabled = false;
                particleSystem?.Stop();
                return;
            }
        }
    }
}
