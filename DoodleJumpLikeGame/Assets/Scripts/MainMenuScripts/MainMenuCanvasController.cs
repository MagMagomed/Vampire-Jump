using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvasController : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private List<Sprite> sprites;

    public DistanceLeaderbordController distanceLeaderbordController;
    private void Start()
    {
        //Yandex.ShowAds();
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
