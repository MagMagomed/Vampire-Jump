using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterGeneratorController : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // префаб платформы
    public float levelWidth = 10f; // ширина уровня
    public PlayerController playerController;
    public float spawnDistance = 200f; // расстояние, на котором создаются платформы

    public float lastMaxHeight;

    private void Update()
    {
        if (playerController.MaxHeight > lastMaxHeight)
        {
            lastMaxHeight = playerController.MaxHeight;
        }
    }
    public void GenerateNextMonster(GameObject platformPrefab)
    {
        var nextMonsterPosition = GenerateNextMonsterPosition();
        _ = Instantiate(platformPrefab, nextMonsterPosition, Quaternion.identity);
    }
    public void GenerateSpecialMonster(GameObject platformPrefab)
    {
        var nextPlatformPosition = GenerateNextMonsterPosition();
        _ = Instantiate(platformPrefab, nextPlatformPosition, Quaternion.identity);
    }
    private Vector2 GenerateNextMonsterPosition()
    {
        // генерируем позицию следующей платформы
        float nextX = Random.Range(-levelWidth, levelWidth);
        float nextY = Random.Range(playerController.gameObject.transform.position.y + 100f, playerController.gameObject.transform.position.y + 200f);
        Vector2 nextPosition = new(nextX, nextY);

        while (CheckOtherObjects(nextPosition))
        {
            nextX = Random.Range(-levelWidth, levelWidth);
            nextY = Random.Range(playerController.gameObject.transform.position.y + 100f, playerController.gameObject.transform.position.y + 200f);
            nextPosition = new Vector2(nextX, nextY);
        }
        return nextPosition;
    }
    public void GenerateRandom()
    {
        var randomInt = Random.Range(0, 5);
        if (randomInt == 0)
        {
            if (GameObject.FindGameObjectsWithTag("Monster").Length < 3)
                GenerateNextMonster(monsterPrefabs[0]);
        }
    }
    private bool CheckOtherObjects(Vector2 nextPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(nextPosition, spawnDistance).Where(col => monsterPrefabs.Any(pref => col.gameObject.CompareTag(pref.tag))).ToArray();
        return colliders.Length != 0;
    }
}
