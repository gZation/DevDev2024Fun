using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : Enemy {


    protected override void Attack(Player player) {
        ResetAttackTimer();
    }

}
