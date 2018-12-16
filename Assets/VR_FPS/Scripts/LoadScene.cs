using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void ToStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene("gameover");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
