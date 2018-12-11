using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour {

    [SerializeField]
    int hp;
    [SerializeField]
    GameObject enemy;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.other.CompareTag("TestGun"))
        {
            this.hp -= 10;
            Debug.Log("hit!");
        }

        if (this.hp <= 0)
        {
            Destroy(this.enemy);
        }
    }
}
