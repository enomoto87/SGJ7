using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour {
    [Header("敵の体力")]
    [SerializeField]
    int hp;
    [Header("敵自身のオブジェクト")]
    [SerializeField]
    GameObject enemy;
    [Header("敵を倒した時の得点")]
    [SerializeField]
    List<int> scoreList;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.other.CompareTag("TestGun"))
        {
            this.hp -= 10;
            Debug.Log("hit!");
        }

        if (this.hp <= 0)
        {
            if(this.enemy.GetComponent<Monster>().getMonster == 0)
            {
                Score.score += scoreList[0];
            }else if(this.enemy.GetComponent<Monster>().getMonster == 1)
            {
                Score.score += scoreList[1];
            }else if(this.enemy.GetComponent<Monster>().getMonster == 2)
            {
                Score.score += scoreList[2];
            }
            Debug.Log("現在の得点 : " + Score.score.ToString());

            Destroy(this.enemy);
        }
    }
}
