using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Item : MonoBehaviour
{
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
