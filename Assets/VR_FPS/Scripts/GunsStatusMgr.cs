using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GunsStatusMgr : ScriptableObject
{
    [Header("武器変更時間")]
    [SerializeField]
    int changeWeaponTime;
    [Header("武器ステータス格納")]
    [SerializeField]
    List<GunStatus> gunsStatus;

    public int getChangeWeaponTime
    {
        get { return changeWeaponTime; }
    }

    public List<GunStatus> getGunsStatus
    {
        get { return gunsStatus; }
    }
}
