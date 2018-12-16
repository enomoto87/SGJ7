using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;
public class ScoreController : MonoBehaviour {
    [SerializeField]
    Text scoreText;
    

	// Use this for initialization
	void Start () {
        int[] highScore = new int[] { 0, 0, 0 };
        for (int i = 0; i < highScore.Length; i++)
        {
            switch (i)
            {
                case 0:
                    highScore[i] = PlayerPrefs.GetInt(Score.no1ScoreKey, 0);
                    break;
                case 1:
                    highScore[2] = PlayerPrefs.GetInt(Score.no2ScoreKey, 0);
                    break;
                case 2:
                    highScore[3] = PlayerPrefs.GetInt(Score.no3ScoreKey, 0);
                    break;
                default:
                    Debug.Log("for error");
                    break;
            }
            if (highScore[i] < Score.score)
            {
                highScore[i] = Score.score;
            }

            switch (i)
            {
                case 0:
                    PlayerPrefs.SetInt(Score.no1ScoreKey, highScore[i]);
                    break;
                case 1:
                    PlayerPrefs.SetInt(Score.no2ScoreKey, highScore[i]);
                    break;
                case 2:
                    PlayerPrefs.SetInt(Score.no3ScoreKey, highScore[i]);
                    break;
                default:
                    Debug.Log("PlayerPrefs error");
                    break;
            }
        }

        this.scoreText.text = "No1 : " + highScore[0].ToString() + 
            "\nNo2 : " + highScore[1].ToString() + 
            "\nNo3 : " + highScore[2].ToString() + 
            "\n\nYour Point : " + Score.score.ToString();
	}
	
}
