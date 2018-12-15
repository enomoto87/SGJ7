using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseGun : MonoBehaviour {

    private GameObject gunImage; //銃のイメージ
    protected GunStatus gunStatus;
    protected float attack; //攻撃力
    protected GameObject bullet; //呼び出される弾丸
    protected AudioClip fireSound; //撃った時の効果音

    private int currentInterval; //インターバル計算における現在のカウント


    public GunStatus GetGunStatus
    {
        get { return this.gunStatus; }
    }

    public int getCurrentInterval
    {
        get { return this.currentInterval; }
    }

    public void setGunStatus(GunStatus gunStatusA)
    {
        this.gunStatus = gunStatusA;
    }

    public void baseInit(GameObject gunImageA, GameObject bulletA, AudioClip fireSoundA)
    {
        this.gunImage = gunImageA;
        this.bullet = bulletA;
        this.fireSound = fireSoundA;
        attack = 1f;

        gunImage.SetActive(false);
    }

    public virtual void init()
    {
        
    }

    //呼び出した直後に呼び出される関数
    public virtual void setup()
    {
        currentInterval = gunStatus.getGunInterval;
        gunImage.SetActive(true);
    }

    //武器を置いたときに呼び出される関数
    public virtual void finish()
    {
        gunImage.SetActive(false);
    }

    //インターバルカウントを減らし、０以下ならshotPointに向けて射撃を試行　撃ったなら1を返す

    public virtual int Shot(Vector3 shotPoint, Vector3 juukouPoint, AudioSource audioSource)
    {
        if (currentInterval <= 0)
        {
            gunShot(shotPoint, juukouPoint, audioSource);

            currentInterval = gunStatus.getGunInterval;
            return 1;
        }
        currentInterval--;
        return 0;
    }

    public void resetInterval()
    {
        currentInterval = gunStatus.getGunInterval;
    }

    //球を撃つ
    protected virtual void gunShot(Vector3 shotPoint, Vector3 juukouPoint, AudioSource audioSource)
    {
        var heading = shotPoint - juukouPoint;
        var direction = Quaternion.LookRotation(heading);

        //Instantiate(this.bullet, this.juukou.transform.position, this.cameraEye.transform.rotation * Quaternion.Euler(-90f, 180f, 0f));
        Instantiate(this.bullet, juukouPoint, direction * Quaternion.Euler(-90f, 180f, 0f));
        audioSource.PlayOneShot(fireSound);
    }

}
