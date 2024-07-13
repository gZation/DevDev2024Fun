using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Item : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    [SerializeField, TextArea] private string description;

    //private SpriteRenderer spriteRenderer;
    //private void Awake()
    //{
    //    spriteRenderer = GetComponent<SpriteRenderer>();    
    //}
    //private void Start()
    //{
    //   spriteRenderer.sprite = itemSprite;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnPickUp(player);
            player.collectedItems.Add(this);
            // TODO: UPDATE UI HERE
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickUp(Player player);
}
