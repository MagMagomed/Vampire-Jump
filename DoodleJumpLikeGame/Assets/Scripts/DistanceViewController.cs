using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceViewController : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent; // ������ �� ��������� Text
    public DistanceController distanceController;
    void Start()
    {
        // ����������� ������ �� ��������� Text
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        // �������� ����� ���������� Text
        textComponent.text = distanceController.GetScore().ToString();
    }
}
