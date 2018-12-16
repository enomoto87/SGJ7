using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPop : MonoBehaviour {

    [SerializeField]
    List<GameObject> enemyList = new List<GameObject>();
    [SerializeField]
    List<GameObject> jellyList = new List<GameObject>();
    [SerializeField]
    int popCount;   //1以上
    [SerializeField]
    int popSpeed;   //1以上
    [SerializeField]
    GameObject cameraEye;

    int popTime = 0;
    int frameTime = 0;


    private void Update()
    {
        Random rand = new Random();
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "Stage1_wataru2")       //ステージ１でのポップ処理
        {
            //float popInt = (-0.0012963f * frameTime + (float)popSpeed) *90f;
            float popInt = (-0.0006963f * frameTime + (float)popSpeed) * 90f;
            if (popInt <= 90f)
                popInt = 90f;
            if (this.popTime >= popInt)
            {
                for (int i = 0; i < popCount; i++)
                {
                    int rnd = Random.Range(0, 4);
                    int jellyRnd = Random.Range(0, 3);
                    GameObject obj = Instantiate(this.jellyList[jellyRnd], this.enemyList[rnd].transform.position, Quaternion.identity);
                    obj.gameObject.GetComponent<BlueJellyMove>().Player = this.cameraEye;
                }
                this.popTime = 0;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage2") //ステージ２でのポップ処理
        {
            //if (this.popTime == this.popSpeed * 60)
            if (this.popTime >= -12.963 * frameTime + (float)popSpeed)
            {
                for (int i = 0; i < popCount; i++)
                {
                    int rnd = Random.Range(4, 8);
                    int jellyRnd = Random.Range(0, 3);
                    Instantiate(this.jellyList[jellyRnd], this.enemyList[rnd].transform.position, Quaternion.identity);
                }
                this.popTime = 0;
            }
        }
        this.popTime++;
        this.frameTime++;
        Debug.Log(frameTime);
    }

}
