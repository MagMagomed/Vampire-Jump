using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    
    [DllImport("__Internal")]
    private static extern void HelloWorld();
    [DllImport("__Internal")]
    private static extern string WhoAreYou();
    [DllImport("__Internal")]
    private static extern void Hello(string name);
    [DllImport("__Internal")]
    private static extern void ShowFullScreenAds();
    public static void ShowAds()
    {
        var bestScore = PlayerPrefs.GetInt("Best score");
        if (bestScore > 0)
        {
            try
            {
                ShowFullScreenAds();
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}
