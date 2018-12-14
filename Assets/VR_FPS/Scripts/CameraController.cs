using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラにくっ付けるプログラム
//参考にしたURL
//http://mslgt.hatenablog.com/entry/2017/02/18/020630

public class CameraController : MonoBehaviour
{
    //マウスの座標を保存する用
    private Vector3 lastMousePosition;
    //回転の計算用
    private Vector3 newAngle = new Vector3(0, 0, 0);

    //Update　毎フレーム呼ばれる命令　60fpsなら1秒間に大体60回(必ずではない)
    private void Update()
    {
        //マウスがクリックされた最初を検知
        if (Input.GetMouseButtonDown(0))
        {
            // マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
            newAngle = transform.localEulerAngles;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            //クリックされ続けている
            // マウスの移動量分カメラを回転させる.
            newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            newAngle.x += (Input.mousePosition.y - lastMousePosition.y) * 0.1f;

            // 新しい回転の数値を代入
            gameObject.transform.localEulerAngles = newAngle;

            lastMousePosition = Input.mousePosition;
        }
    }
}