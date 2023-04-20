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
        // Получаем текущую позицию объекта
        Vector3 position = transform.position;

        // Двигаем объект вправо с заданной скоростью
        position.x += direction * speed * Time.deltaTime;

        // Если объект выходит за правый конец экрана, перемещаем его в левый конец
        if (position.x > rightBound)
        {
            direction = -1;
        }
        if (position.x < leftBound)
        {
            direction = 1;
        }

        // Обновляем позицию объекта
        transform.position = position;
    }
}
