using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float speed = 5f;
    public float leftBound = -10f;
    public float rightBound = 10f;
    [SerializeField] private int direction = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
    void Update()
    {
        // �������� ������� ������� �������
        Vector3 position = transform.position;

        // ������� ������ ������ � �������� ���������
        position.x += direction * speed * Time.deltaTime;

        // ���� ������ ������� �� ������ ����� ������, ���������� ��� � ����� �����
        if (position.x > rightBound)
        {
            direction = -1;
        }
        if (position.x < leftBound)
        {
            direction = 1;
        }

        // ��������� ������� �������
        transform.position = position;
    }
}
