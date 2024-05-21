using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsCanvasController : MonoBehaviour
{
    [SerializeField] private TMP_Text bestLastScore;

    public DistanceLeaderbordController distanceLeaderbordController;
    private void Start()
    {
        var bestScore = PlayerPrefs.GetInt("Best score");
        var lastScore = PlayerPrefs.GetInt("Last score");
        bestLastScore.text = $"Лучший результат: {bestScore}\nПоследний результат: {lastScore}";

        if (CoinsCounterController.instance != null)
        {
            CoinsCounterController.instance.RemoveCoins(CoinsCounterController.instance.GetCoinsCount());
        }
        //distanceLeaderbordController.SaveDistanceToLeaderbord();
    }
    public void OnOkClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
