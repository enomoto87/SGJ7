using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    GameObject bullet;

    int gunType;//銃の種類

    bool isForced = false;
    int age = 0;

    public int getGunType
    {
        get { return this.gunType; }
    }

    public void setGunType(int gunTypeA)
    {
        this.gunType = gunTypeA;
    }

    public void setUp(float forcePower)
    {
        Vector3 force;
        force = this.bullet.transform.up * forcePower;
        this.bullet.GetComponent<Rigidbody>().AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!this.isForced)
        {
            Vector3 force;
            force = this.bullet.transform.up * 0.001f;
            this.bullet.GetComponent<Rigidbody>().AddForce(force);
            this.isForced = true;
        }
        */

        this.age++;
        
        if(age >= 300)
            Destroy(this.bullet);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(this.bullet);
    }
}
