using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs; // префаб платформы
    public int numberOfPlatforms = 12; // количество платформ
    public float levelWidth = 8f; // ширина уровн€
    public float levelMaxWidth = 8f;
    public Camera mainCamera;
    public PlayerController playerController;
    public float spawnDistance = 3f; // рассто€ние, на котором создаютс€ платформы

    [SerializeField] private Vector3 lastPlatformPosition; // последн€€ созданна€ платформа
    [SerializeField] private float distanceBetweenPlatforms = 4f; // рассто€ние между платформами
    public float lastMaxHeight;


    void Start()
    {
        if(playerController.MaxJumpHeight == 0f)
        {
            playerController.Restart();
        }
        levelWidth = GetLevelWidth();
#if UNITY_EDITOR
        distanceBetweenPlatforms = playerController.MaxJumpHeight - playerController.gameObject.transform.localScale.y / 2;
#else
        distanceBetweenPlatforms = playerController.MaxJumpHeight - playerController.gameObject.transform.localScale.y / 2;
#endif
        Debug.Log($"PLATFORM GENERATOR \n\tSTART\n\t\t MaxJumpHeight: {playerController.MaxJumpHeight} \n\t\t PLAYER LOCALSCALE Y: {playerController.gameObject.transform.localScale.y} \n\t\t distanceBetweenPlatforms: {distanceBetweenPlatforms}");

        // генерируем начальную платформу
        Vector3 spawnPosition = new(0f, 0f, 0f);
        Instantiate(platformPrefabs[0], spawnPosition, Quaternion.identity);
        lastPlatformPosition = spawnPosition;

        // генерируем остальные платформы
        for (int i = 0; i < numberOfPlatforms - 1; i++)
        {
            GenerateNextPlatform(platformPrefabs[0]);
        }
    }
    private void Update()
    {
        if (playerController.MaxHeight > lastMaxHeight)
        {
            lastMaxHeight = playerController.MaxHeight;
        }
    }
    public float GetLevelWidth()
    {
        Vector3 rightEdge = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0, mainCamera.nearClipPlane));
        Vector3 leftEdge = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));

        float cameraWidth = Vector3.Distance(rightEdge, leftEdge);

        return levelMaxWidth < cameraWidth / 2 ? levelMaxWidth : cameraWidth / 2 - platformPrefabs.FirstOrDefault().transform.localScale.x;
    }
    public void GenerateNextPlatform(GameObject platformPrefab)
    {
        var nextPlatformPosition = GenerateNextPlatformPosition();
        _ = Instantiate(platformPrefab, nextPlatformPosition, Quaternion.identity);
        lastPlatformPosition = nextPlatformPosition;
    }
    public void GenerateSpecialPlatform(GameObject platformPrefab)
    {
        var nextPlatformPosition = GenerateNextPlatformPosition();
        _ = Instantiate(platformPrefab, nextPlatformPosition, Quaternion.identity);
    }
    private Vector2 GenerateNextPlatformPosition()
    {
        Debug.Log($"PLATFORM GENERATOR \n\tGenerateNextPlatformPosition\n\t\t MaxJumpHeight: {playerController.MaxJumpHeight} \n\t\t PLAYER LOCALSCALE Y: {playerController.gameObject.transform.localScale.y} \n\t\t distanceBetweenPlatforms: {distanceBetweenPlatforms}");

        // генерируем позицию следующей платформы
        float nextX = Random.Range(-levelWidth, levelWidth);
        float nextY = 0f;
#if UNITY_EDITOR
        nextY = Random.Range(lastPlatformPosition.y, lastPlatformPosition.y + distanceBetweenPlatforms);
#else
        nextY = Random.Range(lastPlatformPosition.y, lastPlatformPosition.y + distanceBetweenPlatforms);
#endif
        Vector2 nextPosition = new(nextX, nextY);

        for (int i = 0; i < 50; i++)
        {
            if (!CheckOtherObjects(nextPosition))
            {
                break;
            }
            nextX = Random.Range(-levelWidth, levelWidth);
#if UNITY_EDITOR
            nextY = Random.Range(lastPlatformPosition.y, lastPlatformPosition.y + distanceBetweenPlatforms);
#else
            nextY = Random.Range(lastPlatformPosition.y, lastPlatformPosition.y + distanceBetweenPlatforms);
#endif
            nextPosition = new Vector2(nextX, nextY);
        }
        return nextPosition;
    }
    public void GenerateRandom()
    {
        var randomInt = Random.Range(0, 5);
        if (randomInt == 0)
        {
            if (GameObject.FindGameObjectsWithTag("FakeGround").Length < 3)
                GenerateSpecialPlatform(platformPrefabs[1]);
        }
    }
    private bool CheckOtherObjects(Vector2 nextPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(nextPosition, spawnDistance).Where(col => platformPrefabs.Any(pref => col.gameObject.CompareTag(pref.tag))).ToArray();
        return colliders.Length != 0;
    }
}
