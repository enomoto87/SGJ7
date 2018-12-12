using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRightLeft : MonoBehaviour {

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float moveMax = 100f;
    [SerializeField]
    float moveMin = -100f;

    float moveX;
    float nowSpeed;
    float initX;

	// Use this for initialization
	void Start () {
        moveX = 0f;
        nowSpeed = speed;
        initX = transform.position.x;

    }
	
	// Update is called once per frame
	void Update () {
        moveX += nowSpeed;
        if (moveX > moveMax)
        {
            moveX = moveMax;
            nowSpeed *= -1;
        }else if(moveX < moveMin)
        {
            moveX = moveMin;
            nowSpeed *= -1;
        }

        float x = initX + moveX;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
