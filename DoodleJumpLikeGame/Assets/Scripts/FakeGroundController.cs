using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGroundController : MonoBehaviour
{
	public AudioSource audioSource;
	public FakePlatformAnimationController animationController;
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (gameObject.CompareTag("FakeGround") && collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
			{
				collision.gameObject.GetComponent<PlayerController>().Jump();
				GetComponent<Rigidbody2D>().gravityScale = 3;
				animationController.StartDestroy();
				SoundVoluemController.instance.Play(audioSource);
			}
		}
	}
}
