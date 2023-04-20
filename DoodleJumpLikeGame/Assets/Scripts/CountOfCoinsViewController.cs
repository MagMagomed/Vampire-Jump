using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountOfCoinsViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent; // ������ �� ��������� Text

    void Start()
    {
        // ����������� ������ �� ��������� Text
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // �������� ����� ���������� Text
        textComponent.text = String.Format($"{CoinsCounterController.instance.GetCoinsCount()}");
    }
}
