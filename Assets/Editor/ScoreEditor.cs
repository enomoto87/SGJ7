using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class ScoreEditor : MonoBehaviour
{
    [MenuItem("Tool/PlayerPref/Delete")]
    static void Delete()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Flush();
        Debug.Log("Delete All");
    }
}
