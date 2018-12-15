using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGunSwitch : MonoBehaviour {

    [SerializeField]
    int gunNumber;

    public int getGunNumber()
    {
        return gunNumber;
    }
}
