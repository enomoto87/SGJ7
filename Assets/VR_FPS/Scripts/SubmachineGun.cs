using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmachineGun : BaseGun {

    public override void init()
    {
        this.attack = 10f;
        this.gunInterval = 10;
    }
}
