using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvasController : MonoBehaviour
{
    [SerializeField] private TMP_Text bestLastScore;
    [SerializeField] private Button soundButton;
    [SerializeField] private List<Sprite> sprites;

    public DistanceLeaderbordController distanceLeaderbordController;
    private void Start()
    {
        var bestScore = PlayerPrefs.GetInt("Best score");
        var lastScore = PlayerPrefs.GetInt("Last score");
        bestLastScore.text = $"Best score: {bestScore}\nLast score: {lastScore}";

        if (CoinsCounterController.instance != null)
        {
            CoinsCounterController.instance.RemoveCoins(CoinsCounterController.instance.GetCoinsCount());
        }

        distanceLeaderbordController.SaveDistanceToLeaderbord();
        Yandex.ShowAds();
    }
    private void Update()
    {
        if(SoundVoluemController.instance.isMute)
        {
            soundButton.image.sprite = sprites.FirstOrDefault(s => s.name == "SoundOff");
        }
        else
        {
            soundButton.image.sprite = sprites.FirstOrDefault(s => s.name == "SoundOn");
        }
    }
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnFromAuthorClicked()
    {
        SceneManager.LoadScene("FromAuthor");
    }
    public void OnSoundButtonClicked()
    {
        SoundVoluemController.instance.isMute = !SoundVoluemController.instance.isMute;
    }
}
