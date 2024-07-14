using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProximityAttacker : Attacker {


    protected virtual void OnTriggerStay(Collider other) {
        if (attackTimer <= 0 && other.gameObject.TryGetComponent(out Player player)) {
            Attack(player);
        }
    }

    protected abstract void Attack(Player player);

}
