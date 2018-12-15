using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Aim : MonoBehaviour {

    const int NUM_GUN_TYPE = 2; //銃の種類

    BaseGun[] guns; //銃の配列
    int currentGunIndex; //持っている銃のインデックス

    public Image aimImage;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject cameraEye;
    [SerializeField]
    GameObject juukou;
    [SerializeField]
    GameObject rayShiten;
    [SerializeField]
    Image fireMeter;
    [SerializeField]
    Image gunChangeMeter;

    [SerializeField]
    List<GameObject> switchGunModel;

    [SerializeField]
    GameObject handGunImage;
    [SerializeField]
    GameObject SubmachineGunImage;

    AudioSource audioSource;
    Vector3 reticleEnemyPosition;

    float interval = 0f;
    float maxInterval = 10f;
    bool canShot = false;

    int currentGunChangeCount;
    int maxGunChangeCount = 60;
    int changingGunIndex = -1; //持とうとしている銃の種類

	// Use this for initialization
	void Start () {

        currentGunChangeCount = maxGunChangeCount;
        audioSource = gameObject.GetComponent<AudioSource>();

        guns = new BaseGun[NUM_GUN_TYPE];

        guns[0] = new HandGun();
        guns[1] = new SubmachineGun();

        guns[0].baseInit(handGunImage, bullet, audioSource.clip);
        guns[1].baseInit(SubmachineGunImage, bullet, audioSource.clip);

        for (int i = 0; i < NUM_GUN_TYPE; i++)
        {
            guns[i].init();
        }


        //ハンドガンに持ちかえる
        currentGunIndex = 0;
        chaneGunType(0);
        //audioSource.clip = gunSE;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentGunIndex == 0)
                chaneGunType(1);
            else
                chaneGunType(0);
        }

        bool isShoted = false;
        bool isChangingGun = false;

        //レティクル変化判定
        // レーザー（ray）を飛ばす「起点」と「方向」
        Ray ray = new Ray(this.rayShiten.transform.position, transform.forward);
        Debug.DrawLine(ray.origin, ray.direction * 500, Color.green);

        // rayのあたり判定の情報を入れる箱を作る。
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 60, 1<<8))
        {

            string hitName = hit.transform.gameObject.tag;

            //敵に照準が合っている場合
            if (hitName == "Enemy")
            {
                //Debug.Log(hit.point.x.ToString());//オブジェクトとの接触座標
                //Debug.Log(hit.transform.localPosition.x.ToString());//当たったオブジェクトの座標取得
                // 照準器の色を「赤」に変える（色は自由に変更してください。）
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //敵に向けて射撃
                guns[currentGunIndex].Shot(hit.point, juukou.transform.transform.position, audioSource);
                //Shot(hit.point);
                isShoted = true;

            }
            else
            {

                // 照準器の色を「水色」（色は自由に変更してください。）
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }

            //武器の切り替え
            if(hitName == "GunSwitch")
            {
                int gunType = hit.collider.transform.GetComponent<ChangeGunSwitch>().getGunNumber();
                tryChangeGun(gunType);
                isChangingGun = true;
            }
        }
        else
        {
            // 照準器の色を「水色」（色は自由に変更してください。）
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }

        //照準は敵に合っていないが撃てる状態
        if(canShot && !isShoted)
        {
            float distance = (reticleEnemyPosition - this.cameraEye.transform.position).magnitude;
            Vector3 shotPoint = this.cameraEye.transform.position + this.cameraEye.transform.forward * distance;
            guns[currentGunIndex].Shot(shotPoint, juukou.transform.transform.position, audioSource);
            //Shot(shotPoint);
            isShoted = true;
        }

        //撃てなかった場合はインターバルをリセット
        if (!isShoted)
        {
            guns[currentGunIndex].resetInterval();
            //interval = maxInterval;
        }
        canShot = false;

        //武器を見ていなかった場合カウントをリセット
        if (!isChangingGun)
        {
            noTryChangeGun();
        }

        fireMeter.fillAmount = 1 - ((float)guns[currentGunIndex].getCurrentInterval / guns[currentGunIndex].getGunInterval);
        gunChangeMeter.fillAmount = 1 - ((float)currentGunChangeCount / maxGunChangeCount);
        //fireMeter.fillAmount = 1 - (interval / maxInterval);
    }
    
    /*
    void Shot(Vector3 tyakudanPoint)
    {
        if (this.interval <= 0f)
        {
            var heading = tyakudanPoint - this.juukou.transform.position;
            var direction = Quaternion.LookRotation(heading);

            //Instantiate(this.bullet, this.juukou.transform.position, this.cameraEye.transform.rotation * Quaternion.Euler(-90f, 180f, 0f));
            Instantiate(this.bullet, this.juukou.transform.position, direction * Quaternion.Euler(-90f, 180f, 0f));
            audioSource.PlayOneShot(audioSource.clip);


            this.interval = maxInterval;
        }
        this.interval--;
    }
    */

    //武器の方向を向いている場合持ち変えるか試行する　持ち替えたならTrue
    bool tryChangeGun(int gunIndex)
    {
        Debug.Log("tryChange");
        if(changingGunIndex != gunIndex) //今見ている銃と持ち替えようとしている銃のタイプが違う場合
        {
            currentGunChangeCount = maxGunChangeCount;
            changingGunIndex = gunIndex;
        }
        else if(currentGunChangeCount <= 0)
        {
            chaneGunType(gunIndex);
            currentGunChangeCount = maxGunChangeCount;
        }
        else
        {
            currentGunChangeCount--;
            return false;
        }
        return true;
    }

    void noTryChangeGun()
    {
        changingGunIndex = -1;
        currentGunChangeCount = maxGunChangeCount;
    }

    //銃の持ち替え
    void chaneGunType(int gunIndex)
    {
        
        switchGunModel[currentGunIndex].SetActive(true);
        guns[currentGunIndex].finish();
        Debug.Log(currentGunIndex);

        currentGunIndex = gunIndex;
        guns[currentGunIndex].setup();
        switchGunModel[currentGunIndex].SetActive(false);
        Debug.Log(currentGunIndex);
    }

    //  射撃を許可
    public void allowShot(Vector3 enemyPosision)
    {
        //  Debug.Log("Allowed");
        reticleEnemyPosition = enemyPosision;
        canShot = true;
    }
    
}
