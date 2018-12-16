using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUpdate : MonoBehaviour {

    [SerializeField]
    List<Text> uiTextList;
    [SerializeField]
    int time;
    int i = 0;
	
	// Update is called once per frame
	void Update () {
        this.uiTextList[0].text = "Score : " + Score.score.ToString();
        this.uiTextList[1].text = "time : " +(time - i / 90).ToString();
        i++;
        if (time - (i / 90) <= 0)
        {
            SceneManager.LoadScene("gameover");
        }
	}
}
