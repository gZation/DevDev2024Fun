using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Item : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    [SerializeField] private float weight;
    [SerializeField, TextArea] private string lore;
    [SerializeField, TextArea] private string buff;
    [SerializeField, TextArea] private string debuff;
    public Sprite ItemSprite => itemSprite;
    public string ItemName => itemName;
    public float Weight => weight;
    public string Lore => lore;
    public string Debuff => debuff;
    public string Buff => buff;
    protected bool isCollectible = true;
    private AudioSource audioSource;
    private bool pickedUp = false;

    //private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pickedUp) return;
        if (other.TryGetComponent(out Player player))
        {
            OnPickUp(player);
            audioSource.Play();
            if (isCollectible)
            {
                player.collectedItems.Add(this);
                UIManager.Instance.AddNewCard(this);
            }
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            pickedUp = true;
        }
    }

    protected abstract void OnPickUp(Player player);
}
