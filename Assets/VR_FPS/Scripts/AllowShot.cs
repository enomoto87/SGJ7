using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *　
 */

public class AllowShot : MonoBehaviour {

    [SerializeField]
    Aim aim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Reticle");
        if(other.transform.gameObject.tag == "Enemy")
        {
            aim.allowShot(other.transform.position);
        }
    }
}
