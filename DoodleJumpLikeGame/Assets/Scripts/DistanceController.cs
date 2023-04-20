using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceController : MonoBehaviour
{
    public PlayerController playerController;
    [SerializeField] private int lastMaxHeight;
    [SerializeField] private int score;
    private void Start()
    {
        score = 0;
    }
    private void Update()
    {
        if (playerController.MaxHeight > lastMaxHeight)
        {
            score += playerController.MaxHeight - lastMaxHeight;
            lastMaxHeight = playerController.MaxHeight;

        }
        UpdatePrefs();
    }
    private void UpdatePrefs()
    {
        var bestScore = PlayerPrefs.GetInt("Best score");
        if (bestScore < score)
        {
            PlayerPrefs.SetInt("Best score", score);
        }
        else
        {
            PlayerPrefs.SetInt("Last score", score);
        }
    }
    public float GetScore()
    {
        return score;
    }
}
