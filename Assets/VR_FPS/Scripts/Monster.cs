﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    [SerializeField]
    int monster;

    public int getMonster
    {
        get { return this.monster; }
    }
}
