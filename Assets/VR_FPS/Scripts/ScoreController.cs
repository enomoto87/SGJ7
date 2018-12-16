using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;
public class ScoreController : MonoBehaviour {
    [SerializeField]
    Text scoreText;
    bool isScore = false;
    int tmpI = 0;
    int tmp1Score = 0;
    int tmp2Score = 0;

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
                    if (!isScore)
                    {
                        highScore[i] = PlayerPrefs.GetInt(Score.no2ScoreKey, 0);
                    }
                    else
                    {
                        tmp2Score = highScore[i];
                        highScore[i] = tmp1Score;
                    }
                    break;
                case 2:
                    if (!isScore)
                    {
                        highScore[i] = PlayerPrefs.GetInt(Score.no3ScoreKey, 0);
                    }else if (tmpI == 0)
                    {
                        highScore[i] = tmp2Score;
                    }
                    else
                    {
                        highScore[i] = tmp1Score;
                    }
                    break;
                default:
                    Debug.Log("for error");
                    break;
            }
            if (highScore[i] < Score.score && !isScore)
            {
                tmp1Score = highScore[i];
                highScore[i] = Score.score;
                tmpI = i;
                isScore = true;
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

        PlayerPrefs.Flush();
        Score.score = 0;
        Debug.Log("Save Score and init Score.score = " + Score.score.ToString());

    }
	
}
