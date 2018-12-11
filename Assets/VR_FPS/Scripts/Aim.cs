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

    float interval = 0f;
    float maxInterval = 10f;

	// Use this for initialization
	void Start () {
       audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = gunSE;
	}
	
	// Update is called once per frame
	void Update () {
        // レーザー（ray）を飛ばす「起点」と「方向」
        Ray ray = new Ray(this.rayShiten.transform.position, transform.forward);

        // rayのあたり判定の情報を入れる箱を作る。
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 60, 1<<8))
        {

            string hitName = hit.transform.gameObject.tag;

            if (hitName == "Enemy")
            {
                Debug.Log(hit.point.x.ToString());//オブジェクトとの接触座標
                Debug.Log(hit.transform.localPosition.x.ToString());//当たったオブジェクトの座標取得
                // 照準器の色を「赤」に変える（色は自由に変更してください。）
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                if(this.interval <= 0f)
                {
                    var heading = hit.point - this.juukou.transform.position;
                    var direction = Quaternion.LookRotation(heading);

                    //Instantiate(this.bullet, this.juukou.transform.position, this.cameraEye.transform.rotation * Quaternion.Euler(-90f, 180f, 0f));
                    Instantiate(this.bullet, this.juukou.transform.position, direction * Quaternion.Euler(-90f, 180f, 0f));
                    audioSource.PlayOneShot(audioSource.clip);

           
                    this.interval = maxInterval;
                }
                this.interval--;

            }
            else
            {

                // 照準器の色を「水色」（色は自由に変更してください。）
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                interval = maxInterval;
            }
        }
        else
        {
            // 照準器の色を「水色」（色は自由に変更してください。）
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            interval = maxInterval;
        }

        fireMeter.fillAmount = 1 - (interval / maxInterval);


        /*
        int distance = 100;
        Vector3 rot = new Vector3(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);
        Ray ray = new Ray(transform.position, rot);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 60))
        {
            string hitName = hit.transform.gameObject.tag;

            if (hitName == "Enemy")
            {
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

            }
            else
            {
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
		*/
    }
    
}
