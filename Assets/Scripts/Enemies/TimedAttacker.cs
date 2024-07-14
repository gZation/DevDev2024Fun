using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimedAttacker : Attacker {


    protected override void Update() {
        base.Update();

        if (attackTimer <= 0) {
            Attack();
        }
    }

    protected abstract void Attack();

}
