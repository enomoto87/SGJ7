using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueJellyMove : MonoBehaviour {

    [SerializeField]
    GameObject player;
    [SerializeField]
    float speed = 0.5f;

	// Use this for initialization
	void Start () {
        var heading = player.transform.position - this.transform.position;
        var direction = Quaternion.LookRotation(heading);
        this.transform.rotation = direction;

        Vector3 force;
        force = this.transform.forward * 100;
        this.GetComponent<Rigidbody>().AddForce(force);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
