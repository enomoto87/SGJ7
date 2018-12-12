using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFlameRate : MonoBehaviour {

    void Awake()
    {
        Application.targetFrameRate = 90;
        //Debug.Log("flameSet");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float fps = 1f / Time.deltaTime;
        //Debug.LogFormat("{0}fps", fps);
	}
}
