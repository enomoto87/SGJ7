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
    [Header("連射間隔(注視時間)")]
    [SerializeField]
    int gunInterval;
    [Header("クールタイム")]
    [SerializeField]
    int coolTimeCount = 0;
    [Header("弾のぶれ幅")]
    [SerializeField]
    float shakeRate = 0f;
    [Header("最大装填数")]
    [SerializeField]
    int maxMagazine = 50;
    [Header("弾速(与える力)")]
    [SerializeField]
    float bulletForce = 0.001f;
    //[Header("持っている時のモデル")]
    //[SerializeField]
    //GameObject gunImage;
    //[Header("撃った時の効果音")]
    //[SerializeField]
    //AudioClip sound;


    public int getAttack
    {
        get { return attack; }
    }

    public int getGunInterval
    {
        get { return gunInterval; }
    }

    public int getCoolTimeCount
    {
        get { return coolTimeCount; }
    }

    public float getShakeRate
    {
        get { return shakeRate; }
    }

    public int getMaxMagazine
    {
        get { return maxMagazine; }
    }

    public float getBulletForce
    {
        get { return bulletForce; }
    }

    /*
    public GameObject getGunImage
    {
        get { return gunImage; }
    }
    */

    /*
    public AudioClip getSound
    {
        get { return getSound; }
    }
    */
}
