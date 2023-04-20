using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject[] randomItems;
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Ground").Length > 1)
        {
            GenerateRandomObject();
        }
    }
    private void GenerateRandomObject()
    {
        // генерация случайного индекса для выбора предмета
        int randomIndex = Random.Range(-5, randomItems.Length);
        // создание случайного предмета на платформе
        if(randomIndex >= 0)
        {
            Instantiate(randomItems[randomIndex], transform.position + new Vector3(0, gameObject.GetComponent<Renderer>().bounds.size.y, 0), Quaternion.identity);

            //Instantiate(randomItems[randomIndex], transform.position + new Vector3(0, gameObject.GetComponent<Renderer>().bounds.size.y/2 + randomItems[randomIndex].GetComponent<Renderer>().bounds.size.y / 2, 0), Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.gameObject.CompareTag("Player"))
        {
			if (gameObject.CompareTag("Ground") && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
			{
				collision.gameObject.GetComponent<PlayerController>().Jump();
			}
		}
	}
}
