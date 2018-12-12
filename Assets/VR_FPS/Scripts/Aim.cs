using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Aim : MonoBehaviour {

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

    AudioSource audioSource;
    Vector3 reticleEnemyPosition;

    float interval = 0f;
    float maxInterval = 10f;
    bool canShot = false;

	// Use this for initialization
	void Start () {
       audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = gunSE;
	}
	
	// Update is called once per frame
	void Update () {

        bool isShoted = false;

        //レティクル変化判定
        // レーザー（ray）を飛ばす「起点」と「方向」
        Ray ray = new Ray(this.rayShiten.transform.position, transform.forward);

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
                Shot(hit.point);
                isShoted = true;

            }
            else
            {

                // 照準器の色を「水色」（色は自由に変更してください。）
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
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
            Shot(shotPoint);
            isShoted = true;
        }

        //撃てなかった場合はインターバルをリセット
        if (!isShoted)
        {
            interval = maxInterval;
        }
        canShot = false;

        fireMeter.fillAmount = 1 - (interval / maxInterval);
    }

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

    //  射撃を許可
    public void allowShot(Vector3 enemyPosision)
    {
        //  Debug.Log("Allowed");
        reticleEnemyPosition = enemyPosision;
        canShot = true;
    }
    
}
