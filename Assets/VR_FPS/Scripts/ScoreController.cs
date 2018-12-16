using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    Debug.Log("for error");
                    break;
            }
        }

        this.scoreText.text = "No1 : " + highScore[0].ToString() + 
            "\nNo2 : " + highScore[1].ToString() + 
            "\nNo3 : " + highScore[2].ToString() + 
            "\n\nYour Point : " + Score.score.ToString(); 
	}
	
	
}
