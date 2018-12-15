using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJellyMove : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed = .5f;
    [SerializeField]
    float speedRota = .5f;
    [SerializeField]
    float sinSpeed = .5f;
    float f = 1.0f;
    //float fps = 1f / Time.deltaTime; //フレームレート取得

    float time = 0f;
    [SerializeField]
    float waitTime = 0f;//0より大きい数

    int patan;
    int count = 1;
    float sponPower;
    float sponDeceleration;

    // Use this for initialization

    void Start(){

        patan = Random.Range(0, 5);

        sponPower = Random.Range(1500.0f, 2500.0f);
        sponDeceleration = Random.Range(7.5f, 22.0f);
        this.transform.rotation = Quaternion.Euler(Random.Range(235, 305), Random.Range(90, 270), Random.Range(0, 360)); ;
        Vector3 force;
        force = this.transform.forward * sponPower;
        this.GetComponent<Rigidbody>().AddForce(force);

    }

    // Update is called once per frame
    void Update () {

        if (this.time < waitTime * 90)
        {
            if (sponPower > sponDeceleration * count)
            {
                Vector3 force;
                force = this.transform.forward * sponDeceleration;
                this.GetComponent<Rigidbody>().AddForce(-force);
                count++;
            }

        }
        else
        {
            #region 敵がプレイヤーの方向を向く
            var heading = player.transform.position - this.transform.position;
            var direction = Quaternion.LookRotation(heading);
            this.transform.rotation = direction;
            #endregion

            //    int patan = Random.Range(0, 3);
            Vector3 force;
            force = this.transform.forward * 3;
            this.GetComponent<Rigidbody>().AddForce(force);

            if (patan == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.frameCount * sinSpeed) / 5f + transform.position.y) * f, transform.position.z);
            }
            else if (patan == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.position = new Vector3((Mathf.Cos(Time.frameCount * sinSpeed) / 5f + transform.position.x) * f, transform.position.y, transform.position.z);

            }
            else if (patan == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedRota * Time.deltaTime);
                transform.position = new Vector3((Mathf.Cos(Time.frameCount * sinSpeed) / 5f + transform.position.x) * f, (Mathf.Sin(Time.frameCount * sinSpeed) / 5f + transform.position.y) * f, transform.position.z);
            }
            else if (patan == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedRota * Time.deltaTime);
                transform.position = new Vector3((Mathf.Sin(Time.frameCount * sinSpeed) / 5f + transform.position.x) * f, (Mathf.Cos(Time.frameCount * sinSpeed) / 5f + transform.position.y) * f, transform.position.z);

            }
            
            
            f -= 0.0001f;
        }
        this.time++;
    }

}
