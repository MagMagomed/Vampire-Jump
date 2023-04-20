using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountOfCoinsViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent; // ссылка на компонент Text

    void Start()
    {
        // Присваиваем ссылку на компонент Text
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // Изменяем текст компонента Text
        textComponent.text = String.Format($"{CoinsCounterController.instance.GetCoinsCount()}");
    }
}
