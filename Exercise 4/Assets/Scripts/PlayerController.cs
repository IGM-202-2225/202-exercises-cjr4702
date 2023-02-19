using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 vehiclePosition = new Vector3(0, 0, 0);
    float speed = 0f;
    // Direction vehicle is facing 
    private float x = 0;
    private float y = 0;
    Vector3 direction = new Vector3(0, 0, 0); 
    Vector3 velocity = new Vector3(0, 0, 0);

    void Start()
    {
       
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        float tempx = movementVector.x;
        float tempy = movementVector.y;
        if (tempx != 0 || tempy != 0)
        {
            x = movementVector.x;
            y = movementVector.y;
            direction = new Vector3(x, y, 0);
            speed = 5f;
        }
        else
        {
            speed = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity is direction * speed
        velocity = direction * speed * Time.deltaTime;
        // Add velocity to position 
        vehiclePosition += velocity;
        // “Draw” this vehicle at that position
        transform.position = vehiclePosition;
        // Set the vehicle’s rotation to match the direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

        int width = -Camera.main.pixelWidth;
        int height = Camera.main.pixelHeight;

        int leftBound = 0 - width / 2;
        int rightBound = 0 + width / 2;
        int upperBound = 0 + height / 2;
        int lowerBound = 0 - height / 2;

        if (vehiclePosition.x * 73.5 > leftBound)
        {
            vehiclePosition = new Vector3(rightBound / 73.5f, vehiclePosition.y, 0);
            transform.position = vehiclePosition;
        }
        if(vehiclePosition.x * 73.5 < rightBound)
        {
            vehiclePosition = new Vector3(leftBound / 73.5f, vehiclePosition.y, 0);
            transform.position = vehiclePosition;
        }
        if(vehiclePosition.y * 73.5 < lowerBound)
        {
            vehiclePosition = new Vector3(vehiclePosition.x, upperBound / 74f, 0);
            transform.position = vehiclePosition;
        }
        if (vehiclePosition.y * 73.5 > upperBound)
        {
            vehiclePosition = new Vector3(vehiclePosition.x, lowerBound / 74f, 0);
            transform.position = vehiclePosition;
        }

    }
}
