using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : BaseGun
{

    protected override void gunShot(Vector3 shotPoint, Vector3 juukouPoint, AudioSource audioSource)
    {

        for (int i = 0; i < 5; i++)
        {

            float randX = Random.Range(-5f, 5f);
            float randY = Random.Range(-5f, 5f);

            var heading = shotPoint - juukouPoint;
            var direction = Quaternion.LookRotation(heading);

            //Instantiate(this.bullet, this.juukou.transform.position, this.cameraEye.transform.rotation * Quaternion.Euler(-90f, 180f, 0f));
            Instantiate(this.bullet, juukouPoint, direction * Quaternion.Euler(-90f + randX, 180f + randY, 0f));
            audioSource.PlayOneShot(fireSound);
        }
    }

}

