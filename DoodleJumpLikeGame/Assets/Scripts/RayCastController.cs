using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public PlayerController playerController;
    public CamerController camerController;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - transform.lossyScale.y/2 - 0.0001f), -transform.up * 100f, Color.red);

        _ = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.lossyScale.y/2 - 0.0001f), -transform.up);
    }
}
