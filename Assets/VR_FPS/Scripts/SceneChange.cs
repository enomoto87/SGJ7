using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    int time = 0;
	
	// Update is called once per frame
	void Update () {
        time++;
        if (time > 3000)
        {
            SceneManager.LoadScene("gameover");
        }
	}
}
