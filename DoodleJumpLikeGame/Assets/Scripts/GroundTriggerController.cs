using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggerController : MonoBehaviour
{
    public Collider2D myGroundCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Foot"))
        {
            myGroundCollider.enabled = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Foot"))
        {
            myGroundCollider.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Foot"))
        {
            myGroundCollider.enabled = false;
        }
    }
}
