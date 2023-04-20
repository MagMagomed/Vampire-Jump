using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public DistanceLeaderbordController distanceLeaderbordController;
    Label score;
    Toggle isSoundOn;
    private void Start()
    {
        try
        {
            distanceLeaderbordController.SaveDistanceToLeaderbord();
            Yandex.ShowAds();
        }
        catch
        {
            //
        }
        if(CoinsCounterController.instance != null)
        {
            CoinsCounterController.instance.RemoveCoins(CoinsCounterController.instance.GetCoinsCount());
        }
        var root = GetComponent<UIDocument>().rootVisualElement;
        Button playButton = root.Q<Button>("play-game");
        playButton.clicked += OnPlayButtonClicked;
        score = root.Q<Label>("score");
    }

    private void Update()
    {
        try
        {
            var a = PlayerPrefs.GetInt("Best score");
            var b = PlayerPrefs.GetInt("Last score");
            score.text = $"Best score: {a}\nLast score: {b}";
        } catch(Exception e)
        {
            Debug.Log(e);
        }
    }
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene"); // Загружаем сцену с индексом 1 (можете изменить на свой)
    }
}