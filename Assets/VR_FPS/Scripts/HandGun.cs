using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : BaseGun
{
    public override void init()
    {
        this.attack = 20f;
        this.gunInterval = 45;
    }
}
