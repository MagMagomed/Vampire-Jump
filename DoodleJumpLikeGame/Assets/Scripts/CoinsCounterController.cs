using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCounterController : MonoBehaviour
{
    public static CoinsCounterController instance; // ������ �� ��������
    public AudioSource audioSource;
    [SerializeField] private int coinsCount = 0;
    private int CoinsCount {
        get { return coinsCount; }
        set { coinsCount = value; }
    } // ���������� �����
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
    public void AddCoins(int amount)
    {
        CoinsCount += amount;
        SoundVoluemController.instance.Play(audioSource);
    }

    public void RemoveCoins(int amount)
    {
        CoinsCount -= amount;
    }

    public int GetCoinsCount()
    {
        return CoinsCount;
    }
}
