using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVoluemController : MonoBehaviour
{
    public bool isMute;
    public static SoundVoluemController instance;

    void Awake()
    {
        // Создаем одиночку
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // не уничтожаем объект при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject); // уничтожаем дубликаты
        }
    }
    public void Play(AudioSource audioSource)
    {
        if(!isMute)
        {
            audioSource.Play();
        }
    }
    public void Mute()
    {
        isMute = true;
    }
    public void Unmute()
    {
        isMute = false;
    }
}
