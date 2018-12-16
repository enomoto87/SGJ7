using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseGun : MonoBehaviour {

    protected int gunType; //銃のナンバー
    private GameObject gunImage; //銃のイメージ
    protected GunStatus gunStatus;
    protected float attack; //攻撃力
    protected GameObject bullet; //呼び出される弾丸
    protected AudioClip fireSound; //撃った時の効果音

    protected int currentInterval; //インターバル計算における現在のカウント
    protected int currentCoolTimeCount; //現在のクールタイム終了までのカウント

    protected int currentMagazine;//残り残弾数


    public GunStatus getGunStatus
    {
        get { return this.gunStatus; }
    }

    public int getCurrentInterval
    {
        get { return this.currentInterval; }
    }

    public int getCurrentCoolTimeCount
    {
        get { return currentCoolTimeCount; }
    }

    public int getCurrentMagazine
    {
        get { return currentMagazine; }
    }

    public void setGunStatus(GunStatus gunStatusA)
    {
        this.gunStatus = gunStatusA;
    }

    public void baseInit(int gunIndex, GameObject gunImageA, GameObject bulletA, AudioClip fireSoundA)
    {
        this.gunType = gunIndex;
        this.gunImage = gunImageA;
        this.bullet = bulletA;
        this.fireSound = fireSoundA;
        currentMagazine = gunStatus.getMaxMagazine;
        attack = 1f;
        //this.fireSound = gunStatus.getSound;

        gunImage.SetActive(false);
    }

    public virtual void init()
    {
        
    }

    //呼び出した直後に呼び出される関数
    public virtual void setup()
    {
        currentInterval = gunStatus.getGunInterval;
        currentCoolTimeCount = 0;
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
        if (currentMagazine == 0)
            return 0;
        if (currentCoolTimeCount == 0)
        {
            if (currentInterval <= 0)
            {
                gunShot(shotPoint, juukouPoint, audioSource);

                currentInterval = gunStatus.getGunInterval;
                currentCoolTimeCount = gunStatus.getCoolTimeCount;
                currentMagazine--;
                return 1;
            }
            currentInterval--;
        }
        return 0;
    }

    public void resetInterval()
    {
        currentInterval = gunStatus.getGunInterval;
    }

    public void updateCoolTimeCount()
    {
        if (currentCoolTimeCount > 0)
            currentCoolTimeCount--;
    }

    //手に持っていないときに呼び出される
    public void notHaveUpdate()
    {
        currentMagazine = gunStatus.getMaxMagazine;
    }

    //球を撃つ
    protected virtual void gunShot(Vector3 shotPoint, Vector3 juukouPoint, AudioSource audioSource, bool isPlaySound = true)
    {
        float randX = Random.Range(-gunStatus.getShakeRate, gunStatus.getShakeRate);
        float randY = Random.Range(-gunStatus.getShakeRate, gunStatus.getShakeRate);

        var heading = shotPoint - juukouPoint;
        var direction = Quaternion.LookRotation(heading);

        //Instantiate(this.bullet, this.juukou.transform.position, this.cameraEye.transform.rotation * Quaternion.Euler(-90f, 180f, 0f));
        var instanceBullet = Instantiate(this.bullet, juukouPoint, direction * Quaternion.Euler(-90f+randX, 180f+randY, 0f));
        instanceBullet.GetComponent<Bullet>().setGunType(gunType);
        instanceBullet.GetComponent<Bullet>().setUp(gunStatus.getBulletForce);
        audioSource.PlayOneShot(fireSound);
    }

}
