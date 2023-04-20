using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour
{
    [SerializeField] private float positionY = 0f;
   public PlayerController playerController;
    public void CheckRayCast(RaycastHit2D hit)
    {
        if (hit.collider.CompareTag("Ground") && hit.collider.gameObject.transform.position.y > positionY)
        {
            positionY = hit.collider.gameObject.transform.position.y;
            gameObject.transform.position = new Vector3( gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
    private void Update()
    {
        if (playerController.gameObject.transform.position.y > positionY)
        {
            positionY = playerController.gameObject.transform.position.y;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, positionY, gameObject.transform.position.z);
        }
    }
}
