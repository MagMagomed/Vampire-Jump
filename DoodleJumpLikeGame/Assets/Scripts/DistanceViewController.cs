using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent; // ссылка на компонент Text
    public DistanceController distanceController;
    void Start()
    {
        // Присваиваем ссылку на компонент Text
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // Изменяем текст компонента Text
        textComponent.text = distanceController.GetScore().ToString();
    }
}
