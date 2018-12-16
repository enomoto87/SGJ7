using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAim : MonoBehaviour {

    [SerializeField]
    GameObject cameraEye;
    [SerializeField]
    LoadScene loadScene;

    [SerializeField]
    Image meter;

    int maxCount = 90;
    int currentCount;

	// Use this for initialization
	void Start () {
        currentCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(this.cameraEye.transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 500, Color.green);

        // rayのあたり判定の情報を入れる箱を作る。
        RaycastHit hit;

        bool isSelecting = false;

        if (Physics.Raycast(ray, out hit, 60, 1 << 8))
        {
            if(hit.transform.gameObject.tag == "GunSwitch")
            {
                int buttonType = hit.transform.GetComponent<SelectButton>().selectButtonType;
                currentCount++;

                if(currentCount >= maxCount)
                {
                    push(buttonType);
                }

                isSelecting = true;
            }
        }

        if (!isSelecting)
            currentCount = 0;

        meter.fillAmount = ((float)currentCount / maxCount);

    }

    private void push(int type)
    {
        if(type == 0)
        {
            loadScene.ToStage1();
        }
        if (type == 1)
        {
            loadScene.ExitGame();
        }
        if (type == 2)
        {
            loadScene.ToGameOver();
        }
    }
}
