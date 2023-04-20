using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class DistanceLeaderbordController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddNewRecord(float newRecord);
    internal void SaveDistanceToLeaderbord()
    {
        var bestScore = PlayerPrefs.GetInt("Best score");
        var lastScore = PlayerPrefs.GetInt("Last score");
        if (bestScore == lastScore)
        {
            AddNewRecord(lastScore);
        }
    }
}