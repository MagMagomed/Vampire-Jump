using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVoluemController : MonoBehaviour
{
    public bool isMute;
    public static SoundVoluemController instance;

    void Awake()
    {
        // ������� ��������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ������ ��� �������� ����� �����
        }
        else
        {
            Destroy(gameObject); // ���������� ���������
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
