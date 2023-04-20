using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public PlatformGenerator platformGenerator;
    public MonsterGeneratorController monsterGenerator;
    private float defaulY;
    private float dystance;

    private void Start()
    {
        defaulY = transform.position.y;
        dystance = Mathf.Abs(mainCamera.gameObject.transform.position.y - defaulY);
        mainCamera = Camera.main;
    }
    private void Update()
    {
        var positionY = mainCamera.gameObject.transform.position.y - dystance;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, positionY, gameObject.transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyObject(collision.gameObject);
    }
    
    private void DestroyObject(GameObject gameObject)
    {
        if(gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<PlayerController>().Die();
            return;
        }
        Destroy(gameObject);
        if (!gameObject.CompareTag("Ground"))
        {
            return;
        }
        platformGenerator.GenerateNextPlatform(platformGenerator.platformPrefabs[0]);
        platformGenerator.GenerateRandom();
        monsterGenerator.GenerateRandom();
    }
}
