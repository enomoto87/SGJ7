using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    GameObject bullet;

    bool isForced = false;

    // Update is called once per frame
    void Update()
    {
        if (!this.isForced)
        {
            Vector3 force;
            force = this.bullet.transform.up * 10000;
            this.bullet.GetComponent<Rigidbody>().AddForce(force);
            this.isForced = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(this.bullet);
    }
}
