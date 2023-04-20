using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeakController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (gameObject.CompareTag("Peak") && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
			{
				collision.gameObject.GetComponent<PlayerController>().Die();
			}
		}
	}
}
