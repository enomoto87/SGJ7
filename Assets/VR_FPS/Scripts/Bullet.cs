using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    GameObject bullet;

    bool isForced = false;
    int age = 0;

    // Update is called once per frame
    void Update()
    {
        if (!this.isForced)
        {
            Vector3 force;
            force = this.bullet.transform.up * 0.001f;
            this.bullet.GetComponent<Rigidbody>().AddForce(force);
            this.isForced = true;
        }
        this.age++;
        
        if(age >= 300)
            Destroy(this.bullet);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(this.bullet);
    }
}
