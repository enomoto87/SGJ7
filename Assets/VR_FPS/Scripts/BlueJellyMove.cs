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

    [SerializeField]
    GameObject enemy;
    bool isOne = false;

    // Use this for initialization
    /*
    void Start(){

        patan = Random.Range(0, 5);

        sponPower = Random.Range(1500.0f, 2500.0f);
        sponDeceleration = Random.Range(7.5f, 22.0f);
        this.transform.rotation = Quaternion.Euler(Random.Range(235, 305), Random.Range(90, 270), Random.Range(0, 360)); ;
        Vector3 force;
        force = this.transform.forward * sponPower;
        this.GetComponent<Rigidbody>().AddForce(force);

    }
    */

    // Update is called once per frame
    void Update () {
        if (!this.isOne)
        {

            patan = Random.Range(0, 5);

            sponPower = Random.Range(1500.0f, 2500.0f);
            sponDeceleration = Random.Range(7.5f, 22.0f);
            this.transform.rotation = Quaternion.Euler(Random.Range(235, 305), Random.Range(90, 270), Random.Range(0, 360)); ;
            Vector3 force;
            force = this.transform.forward * sponPower;
            this.GetComponent<Rigidbody>().AddForce(force);
            this.isOne = true;
        }
        else
        {
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
                force = this.transform.forward * speed;
                this.GetComponent<Rigidbody>().AddForce(force);

                
                var centerPoint = new Vector3(player.transform.position.x, this.transform.position.y , this.transform.position.z);
                var centerVec = centerPoint - this.transform.position;
                //Vector3 centerHougaku = (Quaternion.LookRotation(centerVec)).eulerAngles;
                //float centerPower = centerVec.magnitude;
                //Vector3 centerForce = centerHougaku * centerPower * 0.01f;
                Vector3 centerForce = centerVec * 0.1f;

                this.GetComponent<Rigidbody>().AddForce(centerForce);

                var chasePoint = new Vector3((player.transform.position.x - transform.position.x) / 5f, (player.transform.position.y - transform.position.y) / 5f, player.transform.position.z);

                
                if (patan == 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, chasePoint, speedRota * Time.deltaTime);
                    transform.position = new Vector3(transform.position.x, (Mathf.Sin(Time.frameCount * sinSpeed) / 5f + transform.position.y) * f, transform.position.z);
                }
                else if (patan == 1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, chasePoint, speedRota * Time.deltaTime);
                    transform.position = new Vector3((Mathf.Cos(Time.frameCount * sinSpeed) / 5f + transform.position.x) * f, transform.position.y, transform.position.z);

                }
                else if (patan == 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, chasePoint, speedRota * Time.deltaTime);
                    transform.position = new Vector3((Mathf.Cos(Time.frameCount * sinSpeed) / 5f + transform.position.x) * f, (Mathf.Sin(Time.frameCount * sinSpeed) / 5f + transform.position.y) * f, transform.position.z);
                }
                else if (patan == 3)
                {
                    transform.position = Vector3.MoveTowards(transform.position, chasePoint, speedRota * Time.deltaTime);
                    transform.position = new Vector3((Mathf.Sin(Time.frameCount * sinSpeed) / 5f + transform.position.x) * f, (Mathf.Cos(Time.frameCount * sinSpeed) / 5f + transform.position.y) * f, transform.position.z);

                }


                f -= 0.0001f;
            }
        }
        this.time++;
    }

    public GameObject Player
    {
        set { this.player = value; }
    }

}
