using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsController : MonoBehaviour
{
    public float GetLeftEdge()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, Camera.main.nearClipPlane)).x;
    }
    public float GetRightEdge()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, Camera.main.nearClipPlane)).x;
    }
    public float GetTopEdge()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1, Camera.main.nearClipPlane)).y; ;
    }
    public float GetBottomEdge()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, Camera.main.nearClipPlane)).y;
    }
}
