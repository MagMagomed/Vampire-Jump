using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCounterController : MonoBehaviour
{
    public static CoinsCounterController instance; // ссылка на одиночку
    public AudioSource audioSource;
    [SerializeField] private int coinsCount = 0;
    private int CoinsCount {
        get { return coinsCount; }
        set { coinsCount = value; }
    } // количество монет
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
