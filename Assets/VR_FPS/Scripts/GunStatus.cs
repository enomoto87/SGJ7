using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunStatus : ScriptableObject {

    [Header("なまえ")]
    [SerializeField]
    string name;
    [Header("攻撃力")]
    [SerializeField]
    int attack;
    [Header("連射間隔")]
    [SerializeField]
    int gunInterval;
    [Header("注目時間")]
    [SerializeField]
    int gunLookCount = 0;
    //[Header("持っている時のモデル")]
    //[SerializeField]
    //GameObject gunImage;
    [Header("撃った時の効果音")]
    [SerializeField]
    AudioClip sound;


    public int getAttack
    {
        get { return attack; }
    }

    public int getGunInterval
    {
        get { return gunInterval; }
    }

    public int getGunLookCount
    {
        get { return gunLookCount; }
    }

    /*
    public GameObject getGunImage
    {
        get { return gunImage; }
    }
    */


    public AudioClip getSound
    {
        get { return getSound; }
    }

}
