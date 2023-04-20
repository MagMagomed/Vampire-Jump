using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
	public SpringAnimationController springAnimation;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (gameObject.CompareTag("Spring") && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
			{
				springAnimation.StartSpring();
				collision.gameObject.GetComponent<PlayerController>().Jump(2);
			}
		}
	}
}
