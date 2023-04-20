using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public CameraBoundsController cameraBoundsController;
    private void Update()
    {
        if (cameraBoundsController == null)
        {
            return;
        }
        if (cameraBoundsController.GetBottomEdge() > transform.position.y + GetComponent<Renderer>().bounds.size.y / 2)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + GetComponent<Renderer>().bounds.size.y / 2 + GetComponent<Renderer>().bounds.size.y + GetComponent<Renderer>().bounds.size.y / 2,
                transform.position.z
                );
        }
    }
}
