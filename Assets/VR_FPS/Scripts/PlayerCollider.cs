using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnemyHit!");
        if (other.transform.gameObject.tag == "Enemy")
        {
            other.transform.GetComponent<Hp>().dead();
        }
    }

}
