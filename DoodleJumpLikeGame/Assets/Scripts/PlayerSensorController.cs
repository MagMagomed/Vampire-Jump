using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSensorController : MonoBehaviour
{
    [SerializeField] private Vector3 clickPosition;
    [SerializeField] private Vector3 deltaBetweenClickAndPlayer;
    [SerializeField] private Vector2 touchDeltaPosition;

    [SerializeField] private PlayerController controller;
    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (controller.IsDie)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            UpdateClickPosition();
            UpdateDeltaBetweenClickAndPlayer();
        }
        if (Input.GetMouseButton(0)) // Check if the left mouse button is being held down
        {
            UpdateTouchDeltaPosition();
            UpdateClickPosition();
            SetPlayerPosition();
        }
        GuchiFlipFlup();
    }
    private void SetPlayerPosition()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + deltaBetweenClickAndPlayer.x, transform.position.y, transform.position.z);
    }
    private void UpdateDeltaBetweenClickAndPlayer()
    {
        deltaBetweenClickAndPlayer = transform.position - clickPosition;
    }
    private void UpdateTouchDeltaPosition()
    {
        touchDeltaPosition = clickPosition - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void UpdateClickPosition()
    {
        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Store the position of the mouse when the left button was clicked
    }
    private void GuchiFlipFlup()
    {
        if (touchDeltaPosition.x != 0)
        {
            if (touchDeltaPosition.x > 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            }
            else if (touchDeltaPosition.x < 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
            }
        }
        touchDeltaPosition = new Vector2(0, 0);
    }

}
